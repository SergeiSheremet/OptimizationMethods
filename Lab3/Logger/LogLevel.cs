using System;

namespace Lab3.Logger
{
    [Flags]
    public enum LogLevel
    {
        None = 0,
        Result = 1,
        Important = 2,
        Data = 4,
    }
}