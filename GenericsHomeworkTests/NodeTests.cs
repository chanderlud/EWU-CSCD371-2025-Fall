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
}
