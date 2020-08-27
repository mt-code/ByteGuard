using System;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using ByteGuard.Helper.Core;

namespace ByteGuard.Helper
{
    // TODO: Multi-thread this using tasks.
    public class ByteGuardLogin
    {
        /// <summary>
        /// Invoked when/if a successful login occurs.
        /// </summary>
        public event LoginSuccessfulEventHandler LoginSuccessful;

        /// <summary>
        /// Invoked when/if a login fails.
        /// </summary>
        public event LoginFailedEventHandler LoginFailed;

        /// <summary>
        /// Initializes the ByteGuardLogin class, this must be called before any other methods.
        /// </summary>
        public void Initialize()
        {
            Thread threadHwid = new Thread(Hwid.Update)
            {
                IsBackground = true
            };

            threadHwid.Start();
        }

        /// <summary>
        /// Attempts to log in to the ByteGuard servers using the specified credentials.
        /// </summary>
        /// <param name="username">The ByteGuard account username</param>
        /// <param name="password"></param>
        public void Login(string username, string password)
        {
            Network.NetworkError += NetworkError;

            Task.Factory.StartNew(() =>
            {
                NameValueCollection dataValues = new NameValueCollection()
                {
                    { "u", username },
                    { "p", Methods.GetMd5(password) },
                    { "act", "login" }
                };

                while (Hwid.HardwareIdentifier == "NOTSET")
                    Thread.Sleep(250);

                if (Network.SubmitData(dataValues))
                {
                    if (Network.WebResponse.Split('[', ']')[1] == "SUCCESS")
                    {
                        Call(Success);
                    }
                    else
                    {
                        Call(() => Fail(Network.WebResponse.Replace("[ERROR]", String.Empty)));
                    }
                }
            });
        }

        #region EventHandler methods.

        public delegate void LoginSuccessfulEventHandler();
        public delegate void LoginFailedEventHandler(string errorMessage);

        private static void Call(Action action)
        {
            Task.Factory.StartNew(action);
        }

        private void Fail(string error)
        {
            if (LoginFailed != null) LoginFailed(error);
        }

        private void Success()
        {
            if (LoginSuccessful != null) LoginSuccessful();
        }

        private void NetworkError(string error)
        {
            if (LoginFailed != null) LoginFailed(error);
        }

        #endregion
    }
}
