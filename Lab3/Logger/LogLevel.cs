using System;

namespace Lab3.Logger
{
    [Flags]
    public enum LogLevel
    {
        None = 0,
        Result = 1,
        Warning = 3,
        All = 7
    }
}