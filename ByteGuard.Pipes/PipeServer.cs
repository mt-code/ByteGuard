using System;
using System.IO;
using System.Text;
using System.IO.Pipes;
using ByteGuard.Pipes.Core;

namespace ByteGuard.Pipes
{
    public class PipeServer
    {
        // Delegates.
        public delegate void MessageReceivedEventHandler(string message);
        public delegate void ExceptionThrownEventHandler(Exception exception);

        /// <summary>
        /// Invoked when/if a message is received from a client pipe.
        /// </summary>
        public event MessageReceivedEventHandler MessageReceived;

        /// <summary>
        /// Invoked when/if an exception is thrown.
        /// </summary>
        public event ExceptionThrownEventHandler ExceptionThrown;

        // Others.
        private bool _isStopped;
        private readonly string _pipeName;

        public PipeServer(string pipeName)
        {
            _pipeName = pipeName;
        }

        /// <summary>
        /// Starts listening for incoming messages from a pipe client.
        /// </summary>
        public void Start()
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

            // Forces a connection with the server allowing the listen loop to break.
            PipeClient pipeClient = new PipeClient(_pipeName);
            pipeClient.SendMessage("");
        }

        /// <summary>
        /// Sends a message to the pipe server.
        /// </summary>
        /// <param name="message">The message to send to the pipe server.</param>
        public void SendMessage(string message)
        {
            TaskWorker tWorker = new TaskWorker();
            tWorker.WorkException += ThrowException;
            tWorker.DoWork(Send, message);
        }

        #region Read methods.

        private void Listen()
        {
            while (true)
            {
                string serverListenPipeName = String.Format("{0}_server", _pipeName);

                using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(serverListenPipeName))
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
            string clientListenPipeName = String.Format("{0}_client", _pipeName);

            using (NamedPipeClientStream clientStream = new NamedPipeClientStream(clientListenPipeName))
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
