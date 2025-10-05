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

    [TestMethod]
    public void Log_MultipleMessages_WritesEachEntryOnNewLine()
    {
        // Arrange
        const string logPath = "test.log";
        if (File.Exists(logPath))
        {
            File.Delete(logPath);
        }

        LogFactory factory = new();
        factory.ConfigureFileLogger(logPath);
        var logger = factory.CreateLogger(nameof(FileLoggerTests));

        // Act
        logger!.Information("First message");
        logger.Warning("Second message");

        // Assert
        string[] lines = File.ReadAllLines(logPath);
        Assert.AreEqual(2, lines.Length);
        StringAssert.Contains(lines[0], "FileLoggerTests Information First message");
        StringAssert.Contains(lines[1], "FileLoggerTests Warning Second message");
    }

    [TestMethod]
    public void Log_FileDoesNotExist_CreatesFileAndWritesEntry()
    {
        // Arrange
        const string logPath = "test.log";
        if (File.Exists(logPath))
        {
            File.Delete(logPath);
        }

        LogFactory factory = new();
        factory.ConfigureFileLogger(logPath);
        var logger = factory.CreateLogger(nameof(FileLoggerTests));

        // Act
        logger!.Error("Creating log file automatically");

        // Assert
        Assert.IsTrue(File.Exists(logPath));
        string contents = File.ReadAllText(logPath);
        StringAssert.Contains(contents, "FileLoggerTests Error Creating log file automatically");
    }
}
