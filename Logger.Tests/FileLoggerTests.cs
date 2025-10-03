using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public void Log_SimpleMessage_Success()
    {
        LogFactory factory = new();
        factory.ConfigureFileLogger("test.log");
        var logger = factory.CreateLogger(nameof(FileLoggerTests));
        logger.Warning("Hello {0}", 16);

        string contents = File.ReadAllText("test.log");
        Assert.Contains("FileLoggerTests Warning Hello 16", contents);
    }
}
