using System;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ByteGuard.Helper;
using ByteGuard.Hook;

namespace ByteGuard.Tests
{
    public partial class MainForm : Form
    {
        static MainForm()
        {
            JitHook64.Hook();
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*try
            {
                ByteGuardLogin byteguardLogin = new ByteGuardLogin();
                byteguardLogin.LoginSuccessful += SuccessfulLogin;
                byteguardLogin.LoginFailed += FailedLogin;

                byteguardLogin.Initialize();
                byteguardLogin.Login("chewbox", "qawsed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
        }

        private static void FailedLogin(string error)
        {
            MessageBox.Show(error, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void SuccessfulLogin()
        {
            MessageBox.Show("Login successful");
        }

        private void MergeModules()
        {
            ModuleDefMD targetModule = ModuleDefMD.Load(@"A:\Merge\MergerTest.exe");
            ModuleDefMD moduleToInject = ModuleDefMD.Load(@"A:\Merge\MergeLibrary.dll");

            ModuleDef mergedModule = Engine.Merger.Merge(moduleToInject, targetModule);
            mergedModule.Write(@"A:\MergeTest.exe");
        }

        private void InjectType()
        {
            ModuleDefMD targetModule = ModuleDefMD.Load(@"A:\BlankForm.exe");
            ModuleDefMD currentModule = ModuleDefMD.Load(typeof (BlankType).Assembly.ManifestModule);

            TypeDef typeToInject = currentModule.Find("ByteGuard.Tests.TestClass", true);
            TypeDef clonedType = Engine.Cloner.Clone(typeToInject, targetModule);

            MethodDef ctor = targetModule.GlobalType.FindOrCreateStaticConstructor();
            MethodDef test = clonedType.FindMethod("TestMethod");

            ctor.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, test));

            targetModule.Types.Add(clonedType);
            targetModule.Write(@"A:\MergeTest.exe");
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("rofl");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("haha");
        }
    }
}
