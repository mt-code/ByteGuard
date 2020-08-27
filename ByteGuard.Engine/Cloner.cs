using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ByteGuard.Engine
{
    public static class Cloner
    {
        private static Importer _byteguardImporter;
        private static readonly Dictionary<IDnlibDef, IDnlibDef> Content = new Dictionary<IDnlibDef, IDnlibDef>();

        /// <summary>
        ///     Creates an identical TypeDef clone of <paramref name="originalType" /> ready to be added into the specified
        ///     <paramref name="targetModule" />.
        /// </summary>
        /// <param name="originalType">The TypeDef that will be cloned.</param>
        /// <param name="targetModule">The module that the cloned TypeDef will be added to.</param>
        /// <returns>The identical clone of <paramref name="originalType" /></returns>
        public static TypeDef Clone(TypeDef originalType, ModuleDef targetModule)
        {
            Content.Clear();

            _byteguardImporter = new Importer(targetModule, ImporterOptions.TryToUseTypeDefs) { Content = Content };

            MapContent(originalType);

            DuplicateInternals(originalType);

            return (TypeDef) Content[originalType];
        }

        /// <summary>
        ///     Clones the <paramref name="originalType"/> and adds it to the <paramref name="targetModule"/>.
        /// </summary>
        /// <param name="originalType">The TypeDef to inject.</param>
        /// <param name="targetModule">The module that the cloned TypeDef will be injected into.</param>
        /// <returns>The content structure of the injected TypeDef.</returns>
        public static Dictionary<IDnlibDef, IDnlibDef> Inject(TypeDef originalType, ModuleDef targetModule)
        {
            Content.Clear();

            _byteguardImporter = new Importer(targetModule, ImporterOptions.TryToUseTypeDefs) { Content = Content };

            MapContent(originalType);

            DuplicateInternals(originalType);

            targetModule.Types.Add((TypeDef) Content[originalType]);

            return Content;
        }

        private static TypeDefUser Duplicate(TypeDef originalType)
        {
            TypeDefUser returnType = new TypeDefUser(originalType.Name)
            {
                Namespace = originalType.Namespace,
                Attributes = originalType.Attributes,
                ClassLayout =
                    (originalType.HasClassLayout
                        ? new ClassLayoutUser(originalType.ClassLayout.PackingSize, originalType.ClassSize)
                        : null)
            };

            foreach (GenericParam g in originalType.GenericParameters)
                returnType.GenericParameters.Add(new GenericParamUser(g.Number, g.Flags, g.Name));

            return returnType;
        }

        private static MethodDefUser Duplicate(MethodDef originalMethod)
        {
            MethodDefUser returnMethod = new MethodDefUser
            {
                Name = originalMethod.Name,
                Attributes = originalMethod.Attributes,
                ImplMap =
                    (originalMethod.HasImplMap
                        ? new ImplMapUser(
                            new ModuleRefUser(_byteguardImporter.TargetModule, originalMethod.ImplMap.Module.Name),
                            originalMethod.ImplMap.Name, originalMethod.ImplMap.Attributes)
                        : null),
                ImplAttributes = originalMethod.ImplAttributes
            };

            foreach (GenericParam g in originalMethod.GenericParameters)
                returnMethod.GenericParameters.Add(new GenericParamUser(g.Number, g.Flags, g.Name));

            return returnMethod;
        }

        private static FieldDefUser Duplicate(FieldDef originalField)
        {
            return new FieldDefUser
            {
                Name = originalField.Name,
                Attributes = originalField.Attributes
            };
        }

        private static void DuplicateInternals(TypeDef originalType)
        {
            ImportInternals(originalType);

            foreach (TypeDef t in originalType.NestedTypes)
                DuplicateInternals(t);

            foreach (MethodDef m in originalType.Methods)
                ImportInternals(m);

            foreach (FieldDef f in originalType.Fields)
                ImportInternals(f);
        }

        private static CilBody DuplicateMethodBody(CilBody originalBody)
        {
            Dictionary<object, object> bodyContent = new Dictionary<object, object>();

            CilBody returnBody = new CilBody(originalBody.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>())
            {
                MaxStack = originalBody.MaxStack
            };

            foreach (Local l in originalBody.Variables)
                returnBody.Variables.Add((Local) (bodyContent[l] = new Local(_byteguardImporter.Import(l.Type))));
           

            foreach (Instruction i in originalBody.Instructions)
            {
                Instruction _new = new Instruction(i.OpCode, i.Operand);

                if (_new.Operand is IType)
                {
                    _new.Operand = _byteguardImporter.Import((IType) _new.Operand);
                }
                else if (_new.Operand is IMethod)
                {
                    _new.Operand = _byteguardImporter.Import((IMethod) _new.Operand);
                }
                else if (_new.Operand is IField)
                {
                    _new.Operand = _byteguardImporter.Import((IField) _new.Operand);
                }

                returnBody.Instructions.Add((Instruction) (bodyContent[i] = _new));
            }

            foreach (ExceptionHandler e in originalBody.ExceptionHandlers)
            {
                ExceptionHandler newExceptionHandler = new ExceptionHandler
                {
                    HandlerType = e.HandlerType,
                    TryStart = (Instruction) bodyContent[e.TryStart],
                    TryEnd = (Instruction) bodyContent[e.TryEnd],
                    HandlerStart = (Instruction) bodyContent[e.HandlerStart],
                    HandlerEnd = (Instruction) bodyContent[e.HandlerEnd],
                    CatchType = (e.CatchType == null ? null : (ITypeDefOrRef) _byteguardImporter.Import(e.CatchType)),
                    FilterStart = (e.FilterStart == null ? null : (Instruction) bodyContent[e.FilterStart])
                };

                returnBody.ExceptionHandlers.Add(newExceptionHandler);
            }

            foreach (Instruction i in returnBody.Instructions.Where(i => i.Operand != null))
            {
                if (bodyContent.ContainsKey(i.Operand))
                {
                    i.Operand = bodyContent[i.Operand];
                }
                else if (i.Operand is Instruction[])
                {
                    i.Operand = ((Instruction[]) i.Operand).Select(op => (Instruction) bodyContent[op]).ToArray();
                }
            }

            return returnBody;
        }

        private static void ImportInternals(TypeDef originalType)
        {
            TypeDef returnType = (TypeDef) Content[originalType];

            foreach (InterfaceImpl i in originalType.Interfaces)
                returnType.Interfaces.Add(new InterfaceImplUser((ITypeDefOrRef) _byteguardImporter.Import(i.Interface)));

            returnType.BaseType = (ITypeDefOrRef) _byteguardImporter.Import(originalType.BaseType);
        }

        private static void ImportInternals(MethodDef originalMethod)
        {
            MethodDef returnMethod = (MethodDef) Content[originalMethod];

            foreach (CustomAttribute c in originalMethod.CustomAttributes)
                returnMethod.CustomAttributes.Add(
                    new CustomAttribute((ICustomAttributeType) _byteguardImporter.Import(c.Constructor)));

            returnMethod.Signature = _byteguardImporter.Import(originalMethod.Signature);
            returnMethod.Parameters.UpdateParameterTypes();

            if (originalMethod.HasBody)
            {
                returnMethod.Body = DuplicateMethodBody(originalMethod.Body);

                // Prevents: 'Target instruction is too far away for a short branch.' exception.
                returnMethod.Body.SimplifyBranches();
            }
        }

        private static void ImportInternals(FieldDef originalField)
        {
            FieldDef newFieldDef = (FieldDef) Content[originalField];

            newFieldDef.Signature = _byteguardImporter.Import(originalField.Signature);
        }

        private static TypeDef MapContent(TypeDef originalType)
        {
            TypeDef returnType;

            if (Content.ContainsKey(originalType))
            {
                returnType = (TypeDef) Content[originalType];
            }
            else
            {
                returnType = Duplicate(originalType);
                Content[originalType] = returnType;
            }

            foreach (TypeDef t in originalType.NestedTypes)
                returnType.NestedTypes.Add(MapContent(t));

            foreach (MethodDef m in originalType.Methods)
                returnType.Methods.Add((MethodDef) (Content[m] = Duplicate(m)));

            foreach (FieldDef f in originalType.Fields)
                returnType.Fields.Add((FieldDef) (Content[f] = Duplicate(f)));

            return returnType;
        }
    }
}