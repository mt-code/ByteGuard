using System;
using System.Threading.Tasks;

namespace ByteGuard.Pipes.Core
{
    class TaskWorker
    {
        // Delegates.
        internal delegate void ExceptionThrownEventHandler(Exception thrownException);

        /// <summary>
        /// Invoked if/when the task throws an exception.
        /// </summary>
        public event ExceptionThrownEventHandler WorkException;

        /// <summary>
        /// Start a task on a new thread, designed to be used for long running listener threads.
        /// </summary>
        /// <param name="task">The task to run.</param>
        public void DoWork(Action task)
        {
            new Task(() => RunTask(task), TaskCreationOptions.LongRunning).Start();
        }

        /// <summary>
        /// Start a task on a new thread that is called with a string parameter, designed to be used for sending pipe messages.
        /// </summary>
        /// <param name="task">The task to run.</param>
        /// <param name="message">The message that will be passed as a parameter to the task.</param>
        /// <param name="quitAfter">If true, the application will exit after the thread has completed.</param>
        public void DoWork(Action<string> task, string message, bool quitAfter = false)
        {
            new Task(() => RunTask(task, message, quitAfter)).Start();
        }

        private void RunTask(Action task)
        {
            try
            {
                task();
            }
            catch (Exception ex)
            {
                Call(() => Failed(ex));
            }
        }

        private void RunTask(Action<string> task, string message, bool quitAfter)
        {
            try
            {
                task(message);

                if (quitAfter)
                    Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Call(() => Failed(ex));
            }
        }

        private static void Call(Action actionDelegate)
        {
            Task.Factory.StartNew(actionDelegate);
        }

        private void Failed(Exception thrownException)
        {
            if (WorkException != null) WorkException(thrownException);
        }
    }
}
