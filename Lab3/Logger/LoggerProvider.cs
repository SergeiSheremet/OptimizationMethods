using System.Threading;

namespace Lab3.Logger
{
    public static class LoggerProvider
    {
        private static readonly ThreadLocal<ICustomLogger> _logger = new ThreadLocal<ICustomLogger>();

        public static void SetLogger(ICustomLogger logger)
        {
            _logger.Value = logger;
        }
        public static ICustomLogger Logger => _logger.Value ?? new FileLogger("temp.log", LogLevel.None);
    }
}