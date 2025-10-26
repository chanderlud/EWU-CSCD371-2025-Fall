namespace GenericsHomework;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }

    public void Clear()
    {
          Next = this;
    }

    override public string ToString()
    {
        return Value?.ToString() ?? "null";
    }
}
