using System.Collections;

namespace GenericsHomework;

public class Node<T> : ICollection<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; private set; }

    public Node(T value)
    {
        Value = value;
        Next = this;
    }
    
    public int Count
    {
        get
        {
            int count = 0;
            Node<T> current = this;
            do
            {
                count++;
                current = current.Next;
            } while (current != this);
            return count;
        }
    }

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        Node<T> newNode = new Node<T>(item);

        Node<T> current = this;
        while (current.Next != this)
        {
            current = current.Next;
        }

        current.Next = newNode;
        newNode.Next = this;
    }

    public void Clear()
    {
        Value = default!;
        Next = this;
    }

    public bool Contains(T item)
    {
        Node<T> current = this;
        do
        {
            if (item is null && current.Value is null)
                return true;
            if (current.Value is not null && current.Value.Equals(item))
                return true;

            current = current.Next;
        } while (current != this);

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
            throw new ArgumentNullException(nameof(array));

        Node<T> current = this;
        int i = arrayIndex;
        do
        {
            array[i++] = current.Value;
            current = current.Next;
        } while (current != this);
    }

    public bool Remove(T item)
    {
        Node<T> current = this;
        Node<T> previous = null!;

        do
        {
            if ((item is null && current.Value is null) ||
                (current.Value is not null && current.Value.Equals(item)))
            {
                if (previous != null)
                {
                    previous.Next = current.Next;
                }
                else
                {
                    Value = current.Next.Value;
                    Next = current.Next.Next;
                }
                return true;
            }

            previous = current;
            current = current.Next;
        } while (current != this);

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = this;
        do
        {
            yield return current.Value;
            current = current.Next;
        } while (current != this);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public bool Exists(T value)
    {
        Node<T> current = this;
        do
        {
            if (value is null && current.Value is null)
            {
                return true;
            }
            else if (current.Value is not null && current.Value.Equals(value))
            {
                return true;
            }
            current = current.Next;
        } while (current != this);
        return false;
    }

    public override string ToString() => Value?.ToString() ?? "null";
}
