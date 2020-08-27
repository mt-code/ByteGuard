using System;
using System.Windows.Forms;

namespace ByteGuard.Tests
{
    class TestClass
    {
        public static void TestMethod()
        {
            const int x = 10;
            const int y = 5;

            MessageBox.Show(ReturnMethod().ToString());


            MessageBox.Show("this is a test method");
            MessageBox.Show(String.Format("The sum = {0}", (x + y)));
        }

        private static int ReturnMethod()
        {
            return 1337;
        }

        public class AnotherClass
        {
            private static void AnotherMethod()
            {
                try
                {
                    Console.WriteLine("This is in an exception handler!");
                }
                catch
                {
                    Console.WriteLine("An exception has occured!");
                }
            }
        }
    }
}
