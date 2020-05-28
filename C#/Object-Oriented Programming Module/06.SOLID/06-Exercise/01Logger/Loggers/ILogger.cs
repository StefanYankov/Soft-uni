using Logger.Appenders;

namespace Logger.Loggers
{
    public interface ILogger
    {
        IAppender Appender { get; }
        void Error(string dateTime, string message);

        void Info(string dateTime, string message);
    }
}
