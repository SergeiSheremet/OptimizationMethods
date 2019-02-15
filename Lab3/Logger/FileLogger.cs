using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lab3.Logger
{
    public class FileLogger : ICustomLogger
    {
        private readonly LogLevel _logLevel;
        private readonly string _fileName;
        public FileLogger(string fileName, LogLevel logLevel)
        {
            _fileName = fileName;
            _logLevel = logLevel;
            File.Delete(_fileName);
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

        public void Log<T>(string title, IEnumerable<T> message, LogLevel level,
            [CallerFilePath]string path = "",
            [CallerMemberName]string method = "",
            [CallerLineNumber]int line = 0)
        {
            string prefix = GetPrefix(path, method, line) + $"{title}: ";
            string arrayForLog;

            if (message.First() is IEnumerable)
            {
                List<string> dataList = new List<string>();
                foreach (var e in message)
                {
                    List<string> subRes = new List<string>();
                    foreach (var subElement in (e as IEnumerable))
                    {
                        subRes.Add(subElement.ToString());
                    }
                    dataList.Add(ArrayToString(subRes));
                }
                arrayForLog = $"\r\n{AddTab(prefix.Length)}" + string.Join($"\r\n{AddTab(prefix.Length)}", dataList);
            }
            else
            {
                arrayForLog = ArrayToString(message);
            }

            WriteToFile($"{prefix}[{arrayForLog}]", level);
        }

        private void WriteToFile(string text, LogLevel level)
        {
            using (StreamWriter stream = File.AppendText(_fileName))
            {
                if (_logLevel >= level)
                {
                    stream.WriteLine($"{text}");
                }
            }
        }

        private string GetPrefix(string path, string method, int line)
        {
            string className = path.Split("\\").Last().Split("/").Last();
            string prefix = $"[{className,-25}]";
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
            return string.Join(", ", array);
        }
    }
}