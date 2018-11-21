using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Lab3.Logger
{
    public interface ICustomLogger
    {
        void Log(string message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0);

        void Log(string title, string message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0);

        void Log(string title, double[] message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0);

        void Log(string title, double[][] message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0);

        void Log(string title, List<List<double>> message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0);

        void Save();
    }
}