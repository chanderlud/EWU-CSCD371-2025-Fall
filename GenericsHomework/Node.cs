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

    public bool Exists(T value)
    {
        Node<T> current = this;
        do
        {
            if (current.Value!.Equals(value))
            {
                return true;
            }
            current = current.Next;
        } while (current != this);
        return false;
    }
}
