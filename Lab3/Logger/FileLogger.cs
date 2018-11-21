using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lab3.Logger
{
    public class FileLogger : ICustomLogger
    {
        private readonly StreamWriter _stream;
        private readonly LogLevel _logLevel;
        public FileLogger(string fileName, LogLevel logLevel)
        {
            _logLevel = logLevel;
            if (File.Exists(fileName))
                File.Delete(fileName);
            _stream = new StreamWriter(File.OpenWrite(fileName)) {AutoFlush = true};
        }

        public void Log(string message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0)
        {
            string prefix = GetPrefix(path, method, line);
            WriteToFile($"{prefix}{message}", level);
        }

        public void Log(string title, string message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0)
        {
            string prefix = GetPrefix(path, method, line) + $"{title}: ";
            WriteToFile($"{prefix}{message}", level);
        }

        public void Log(string title, double[] message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0)
        {
            string prefix = GetPrefix(path, method, line) + $"{title}: ";
            WriteToFile($"{prefix}[{ArrayToString(message)}]", level);
        }

        public void Log(string title, double[][] message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0)
        {
            string prefix = GetPrefix(path, method, line) + $"{title}: ";
            string arrayForLog = string.Join($"\n{AddTab(prefix.Length)}", message.Select(ArrayToString));
            WriteToFile($"{prefix}[{arrayForLog}]", level);
        }

        public void Log(string title, List<List<double>> message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0)
        {
            Log(title, message.Select(f => f.Select(s => s).ToArray()).ToArray(), level, path, method, line);
            string prefix = GetPrefix(path, method, line) + $"{title}: ";
            string arrayForLog = string.Join($"\n{AddTab(prefix.Length)}", message.Select(ArrayToString));
            WriteToFile($"{prefix}[{arrayForLog}]", level);
        }

        public void Save()
        {
            _stream.Close();
        }

        private void WriteToFile(string text, LogLevel level)
        {
            if (level == LogLevel.All)
                throw new ArgumentException(nameof(level));

            //TODO: check log level
            if ((_logLevel & level) != LogLevel.None)
            {
                _stream.WriteLine($"{text}");
            }
        }

        private string GetPrefix(string path, string method, int line)
        {
            string className = path.Split("\\").Last().Split("/").Last();
            string prefix = $"[{DateTime.Now:hh:mm:ss.fff}][{className,-25}][{method,-10}][{line,3}] ";
            return prefix;
        }

        private string AddTab(int count)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                builder.Append(' ');
            }
            return builder.ToString();
        }

        private string ArrayToString<T>(IEnumerable<T> array)
        {
            return string.Join(',', array);
        }
    }
}