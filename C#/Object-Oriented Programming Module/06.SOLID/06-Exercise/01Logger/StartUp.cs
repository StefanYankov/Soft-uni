namespace Logger
{
    using System;
    using Layouts;
    using Appenders;;
    public class StartUp
    {
        static void Main()
        {
            var simpleLayout = new SimpleLayout();
            Console.WriteLine(string.Format(simpleLayout.Format, "test", "test","test"));
            var consoleAppender = new ConsoleAppender(simpleLayout);
            /*
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            ILogger logger = new Logger(consoleAppender);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
            */
        }
    }
}
