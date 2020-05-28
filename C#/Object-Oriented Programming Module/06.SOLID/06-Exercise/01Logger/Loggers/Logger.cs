using Logger.Appenders;

namespace Logger.Loggers
{
    public class Logger : ILogger
    {
        public Logger(IAppender appender)
        {
            this.Appender = appender;
        }
        public IAppender Appender { get; }
        public void Error(string dateTime, string message)
        {
            this.Appender.Append();
        }

        public void Info(string dateTime, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
