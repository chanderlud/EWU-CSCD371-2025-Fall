using GenericsHomework;

namespace GenericsHomeworkTests;

public class NodeTests
{
    [Fact]
    public void Constructor_SingleIntNode_PointsToItself()
    {
        Node<int> node = new(0);
        Assert.Equal(0, node.Value);
        Assert.Equal(node, node.Next);
    }

    [Fact]
    public void ToString_NullValue_ReturnsNullString()
    {
        Node<string> node = new(null!);
        Assert.Equal("null", node.ToString());
    }

    [Fact]
    public void ToString_IntValue_ReturnsIntString()
    {
        Node<int> node = new(100);
        Assert.Equal("100", node.ToString());
    }

    [Fact]
    public void Exists_NodeWithSameIntValue_ReturnsTrue()
    {
        Node<string> node = new("test");
        Assert.True(node.Exists("test"));
    }

    [Fact]
    public void Exists_NodeWithSameNullValue_ReturnsTrue()
    {
        Node<string> node = new(null!);
        Assert.True(node.Exists(null!));
    }

    [Fact]
    public void Exists_NodeWithDifferentValue_ReturnsFalse()
    {
        Node<int> node = new(10);
        Assert.False(node.Exists(100));
    }

    [Fact]
    public void Clear_NodeWithMultipleValues_ClearsAllButHead()
    {
        Node<int> node = new(1);
        node.Add(2);
        node.Add(3);

        node.Clear();

        Assert.True(node.Exists(default!)); // Value reset to default
        Assert.DoesNotContain(2, node);
        Assert.DoesNotContain(3, node);
        Assert.Equal(node, node.Next);
    }

    [Fact]
    public void Add_SingleNewValue_AppendsSuccessfully()
    {
        Node<int> node = new(1);
        node.Add(2);

        Assert.Equal(2, node.Next.Value);
        Assert.Equal(node, node.Next.Next);
        Assert.Equal(2, node.Count);
    }

    [Fact]
    public void Add_MultipleValues_FormsCircularList()
    {
        Node<int> node = new(1);
        node.Add(2);
        node.Add(3);

        var values = new List<int>(node);
        Assert.Equal(new[] { 1, 2, 3 }, values);
        Assert.Equal(3, node.Count);
        Assert.Equal(node, node.Next.Next.Next);
    }

    [Fact]
    public void Contains_ExistingValue_ReturnsTrue()
    {
        Node<int> node = new(5);
        node.Add(10);
        Assert.Contains(10, node);
    }

    [Fact]
    public void Contains_NonExistingValue_ReturnsFalse()
    {
        Node<int> node = new(1);
        node.Add(2);
        Assert.DoesNotContain(3, node);
    }

    [Fact]
    public void Remove_ExistingValue_RemovesSuccessfully()
    {
        Node<int> node = new(1);
        node.Add(2);
        node.Add(3);

        bool removed = node.Remove(2);
        Assert.True(removed);
        Assert.DoesNotContain(2, node);
        Assert.Equal(2, node.Count);
    }

    [Fact]
    public void Remove_HeadValue_ReplacesWithNext()
    {
        Node<int> node = new(1);
        node.Add(2);
        node.Add(3);

        bool removed = node.Remove(1);
        Assert.True(removed);
        Assert.DoesNotContain(1, node);
        Assert.Contains(2, node);
        Assert.Contains(3, node);
        Assert.Equal(2, node.Count);
    }

    [Fact]
    public void Remove_NonExistingValue_ReturnsFalse()
    {
        Node<int> node = new(1);
        node.Add(2);
        Assert.False(node.Remove(3));
        Assert.Equal(2, node.Count);
    }

    [Fact]
    public void CopyTo_CopiesElementsToArraySuccessfully()
    {
        Node<int> node = new(10);
        node.Add(20);
        node.Add(30);

        int[] arr = new int[5];
        node.CopyTo(arr, 1);

        Assert.Equal(0, arr[0]);
        Assert.Equal(10, arr[1]);
        Assert.Equal(20, arr[2]);
        Assert.Equal(30, arr[3]);
    }

    [Fact]
    public void CopyTo_NullArray_ThrowsException()
    {
        Node<int> node = new(1);
        Assert.Throws<ArgumentNullException>(() => node.CopyTo(null!, 0));
    }

    [Fact]
    public void Enumerator_IteratesAllValuesOnce()
    {
        Node<int> node = new(1);
        node.Add(2);
        node.Add(3);

        var result = new List<int>();
        foreach (int value in node)
            result.Add(value);

        Assert.Equal(new[] { 1, 2, 3 }, result);
    }

    [Fact]
    public void IsReadOnly_ReturnsFalse()
    {
        Node<int> node = new(1);
        Assert.False(node.IsReadOnly);
    }

    [Fact]
    public void Count_ReturnsCorrectNumberOfElements()
    {
        Node<int> node = new(1);
        node.Add(2);
        node.Add(3);
        Assert.Equal(3, node.Count);
    }
}
