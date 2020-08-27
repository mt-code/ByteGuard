using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// TODO: Remove.
using System.Windows.Forms;

namespace ByteGuard.Licensing
{
    public class Licensing
    {
        public static void Initialize(string ProgramID)
        {

        }

        public static int GetVariable(string VariableKey)
        {
            MessageBox.Show(Assembly.GetCallingAssembly().FullName);
            return 0;
        }
    }
}
