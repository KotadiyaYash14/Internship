using NLog;

namespace CoreDemoApp.Logger
{
    public class LoggerManager : ILoggerManager
    {
        #region Fields

        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructor

        public LoggerManager()
        {
        }

        #endregion

        #region Methods

        public void Information(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        #endregion
    }
}
