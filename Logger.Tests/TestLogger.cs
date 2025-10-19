namespace Logger.Tests;

public class TestLogger : BaseLogger
{
    public TestLogger(string logSource) : base(logSource) { }

    public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = [];

    //public static ILogger CreateLogger(in TestLoggerConfiguration configuration) =>
    //    ;

    public override ILogger CreateLogger(in ILoggerConfiguration configuration) =>
        configuration is TestLoggerConfiguration testLoggerConfiguration
            ? new TestLogger(configuration.LogSource)
            : throw new ArgumentException("Invalid configuration type", nameof(configuration));

    public override void Log(LogLevel logLevel, string message) => LoggedMessages.Add((logLevel, message));
}

public class TestLoggerConfiguration : BaseLoggerConfiguration, ILoggerConfiguration
{
    public TestLoggerConfiguration(string logSource) : base(logSource) { }

}
