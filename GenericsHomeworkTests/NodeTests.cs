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

    [Fact]
    public void Exists_NodeWithSameIntValue_ReturnsTrue()
    {
        // Arrange
        Node<string> node = new("test");

        // Act
        bool exists = node.Exists("test");

        // Assert
        Assert.True(exists);
    }

    [Fact]
    public void Exists_NodeWithSameNullValue_ReturnsTrue()
    {
        // Arrange
        Node<string> node = new(null!);

        // Act
        bool exists = node.Exists(null!);

        // Assert
        Assert.True(exists);
    }

    [Fact]
    public void Exists_NodeWithDifferentValue_ReturnsFalse()
    {
        // Arrange
        Node<int> node = new(10);

        // Act
        bool exists = node.Exists(100);

        // Assert
        Assert.False(exists);
    }

    [Fact]
    public void Clear_NodeWithMultipleValues_ClearsAllButHead()
    {
        // Arrange
        Node<int> node = new(1);
        node.Append(2);
        node.Append(3);

        // Act
        node.Clear();

        // Assert
        Assert.False(node.Exists(2));
        Assert.False(node.Exists(3));
        Assert.True(node.Exists(1));
    }

    [Fact]
    public void Append_NewValue_AppendsNodeSuccessfully()
    {
        // Arrange
        Node<int> node = new(1);

        // Act
        node.Append(2);

        // Assert
        Assert.Equal(2, node.Next.Value);
        Assert.Equal(node, node.Next.Next);
    }

    [Fact]
    public void Append_DuplicateValue_ThrowsArgumentException()
    {
        // Arrange
        Node<int> node = new(1);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => node.Append(1));
    }
}
