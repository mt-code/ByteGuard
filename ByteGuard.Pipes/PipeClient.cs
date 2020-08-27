using System;
using System.IO;
using System.Text;
using System.IO.Pipes;
using ByteGuard.Pipes.Core;

namespace ByteGuard.Pipes
{
    public class PipeClient
    {
        // Delegates.
        public delegate void ExceptionEventHandler(Exception exception);

        public delegate void MessageReceivedEventHandler(string message);

        /// <summary>
        /// Invoked when/if a message is received from a client pipe.
        /// </summary>
        public event MessageReceivedEventHandler MessageReceived;

        /// <summary>
        /// Invoked when/if an exception is thrown.
        /// </summary>
        public event ExceptionEventHandler ExceptionThrown;

        // Others.
        private bool _isStopped;
        private readonly string _pipeName;

        public PipeClient(string pipeName)
        {
            _pipeName = pipeName;
        }

        /// <summary>
        /// Connects to a listening pipe server and starts listening for incoming messages.
        /// </summary>
        public void Connect()
        {
            TaskWorker tWorker = new TaskWorker();
            tWorker.WorkException += ThrowException;
            tWorker.DoWork(Listen);
        }

        /// <summary>
        /// Stops the pipe server from listening for incoming messages.
        /// </summary>
        public void Stop()
        {
            _isStopped = true;

            // Forces a connection with the client allowing the listen loop to break.
            PipeServer pipeServer = new PipeServer(_pipeName);
            pipeServer.SendMessage("");
        }

        /// <summary>
        /// Sends a message to the pipe server.
        /// </summary>
        /// <param name="message">The message to send to the pipe server.</param>
        /// <param name="quitAfter">If true, the application will exit after the thread has completed.</param>
        public void SendMessage(string message, bool quitAfter = false)
        {
            TaskWorker tWorker = new TaskWorker();
            tWorker.WorkException += ThrowException;
            tWorker.DoWork(Send, message);
        }

        #region Read methods.

        private void Listen()
        {
            string clientListenPipeName = String.Format("{0}_client", _pipeName);

            while (true)
            {
                using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(clientListenPipeName))
                {
                    pipeServer.WaitForConnection();

                    if (_isStopped) break;

                    byte[] buffer = ReadStreamData(pipeServer);

                    if (MessageReceived != null) MessageReceived(Encoding.ASCII.GetString(buffer));
                }
            }
        }

        private static byte[] ReadStreamData(Stream inputStream)
        {
            byte[] streamBuffer = new byte[16 * 1024];

            using (MemoryStream memoryStream = new MemoryStream())
            {
                int bytesRead;
                while ((bytesRead = inputStream.Read(streamBuffer, 0, streamBuffer.Length)) > 0)
                {
                    memoryStream.Write(streamBuffer, 0, bytesRead);
                }

                return memoryStream.ToArray();
            }
        }

        #endregion

        #region Send methods.

        private void Send(string message)
        {
            string serverListenPipeName = String.Format("{0}_server", _pipeName);

            using (NamedPipeClientStream clientStream = new NamedPipeClientStream(serverListenPipeName))
            {
                clientStream.Connect();

                byte[] messageBuffer = Encoding.ASCII.GetBytes(message);

                clientStream.Write(messageBuffer, 0, messageBuffer.Length);
            }
        }

        #endregion

        private void ThrowException(Exception exception)
        {
            if (ExceptionThrown != null) ExceptionThrown(exception);
        }
    }
}
