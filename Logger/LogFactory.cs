using System;

namespace Logger;

public class LogFactory
{
    string? _filePath;

    public BaseLogger? CreateLogger(string className)
    {
        if (_filePath == null)
        {
            return null;
        }
        else
        {
            return new FileLogger(_filePath)
            {
                ClassName = className,
            };
        }
    }

    public void ConfigureFileLogger(string filePath)
    {
        _filePath = filePath;
    }
}
