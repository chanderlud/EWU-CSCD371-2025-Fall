using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    [TestMethod]
    public void CreateLogger_FileLogger_Success()
    {
        LogFactory factory = new();
        factory.ConfigureFileLogger("test.log");
        var logger = factory.CreateLogger(nameof(LogFactoryTests));
        Assert.AreEqual(logger.ClassName, nameof(LogFactoryTests));
    }

    [TestMethod]
    public void CreateLogger_FileLogger_NullFilePath()
    {
        LogFactory factory = new();
        var logger = factory.CreateLogger(nameof(LogFactoryTests));
        Assert.IsNull(logger);
    }
}
