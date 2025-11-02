namespace Calculate.Tests
{
    [TestClass]
    public sealed class ProgramTests
    {
        [TestMethod]
        public void Program_WriteLineAndReadLine_WorkCorrectly()
        {
            // Arrange
            string expectedOutput = "Hello, World!";
            string expectedInput = "6 + 7";
            string actualInput = string.Empty;

            Program program = new()
            {
                WriteLine = (output) => actualInput = output,
                ReadLine = () => expectedInput
            };

            // Act
            program.WriteLine(expectedOutput);
            string? actualInput = program.ReadLine();

            // Assert
            Assert.AreEqual(expectedOutput, actualInput);
            Assert.AreEqual(expectedInput, actualInput);

        }
    }
}
