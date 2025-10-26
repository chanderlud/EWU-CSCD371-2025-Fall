using GenericsHomework;

namespace GenericsHomeworkTests;

public class NodeTests
{
    [Fact]
    public void Constructor_SingleIntNode_PointsToItself()
    {
        // Arrange & Act
        Node<int> node = new(0);

        // Assert
        Assert.Equal(0, node.Value);
        Assert.Equal(node, node.Next);
    }

    [Fact]
    public void ToString_NullValue_ReturnsNullString()
    {
        // Arrange
        Node<string> node = new(null!);

        // Act
        string result = node.ToString();

        // Assert
        Assert.Equal("null", result);
    }

    [Fact]
    public void ToString_IntValue_ReturnsIntString()
    {
        // Arrange
        Node<int> node = new(100);

        // Act
        string result = node.ToString();

        // Assert
        Assert.Equal("100", result);
    }
}
