using System.Threading;

namespace Lab3.Logger
{
    public static class LoggerProvider
    {
        public static readonly ThreadLocal<ICustomLogger> Logger = new ThreadLocal<ICustomLogger>();
    }
}