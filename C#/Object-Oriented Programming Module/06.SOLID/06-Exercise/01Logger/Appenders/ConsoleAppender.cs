using System;
using Logger.Layouts;

namespace Logger.Appenders
{
    class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }
        public void Append(string message)
        {
            Console.WriteLine(message);
        }
    }
}
