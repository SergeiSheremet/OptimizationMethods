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

        void Log<T>(string title, T[] message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0);

        void Log<T>(string title, T[][] message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0);

        void Log<T>(string title, List<List<T>> message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0);

        void Save();
    }
}