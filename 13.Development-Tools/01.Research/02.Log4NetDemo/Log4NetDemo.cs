namespace Log4NetDemo
{
    using log4net;
    using log4net.Config;

    public class Log4NetTest
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Log4NetTest));

        public static void Main()
        {
            BasicConfigurator.Configure();
            Logger.Debug("This is debug log message.");
            Logger.Info("This is info log message.");
            Logger.Warn("This is warning log message.");
            Logger.Error("This is error log message.");
            Logger.Fatal("This is fatal error log message.");
        }
    }
}