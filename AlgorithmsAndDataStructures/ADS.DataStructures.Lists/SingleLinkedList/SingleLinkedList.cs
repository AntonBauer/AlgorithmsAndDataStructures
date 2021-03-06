using System.Collections;
using ADS.DataStructures.Lists.Extensions;

namespace ADS.DataStructures.Lists.SingleLinkedList;

public class SingleLinkedList<T> : IEnumerable<T>
{
    private ListNode<T>? _head;

    private bool IsEmpty => _head is null;

    public SingleLinkedList()
    {
    }

    public SingleLinkedList(T value) => Add(value);

    public SingleLinkedList(IEnumerable<T> values) => AddRange(values);

    public IEnumerator<T> GetEnumerator()
    {
        if (IsEmpty)
            yield break;

        var current = _head;
        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Add(T value)
    {
        if (IsEmpty)
        {
            _head = new ListNode<T>(value);
            return;
        }

        var current = _head;
        while (current!.Next is not null)
            current = current.Next;

        current.Next = new ListNode<T>(value);
    }

    public void AddRange(IEnumerable<T> values) => values.ForEach(Add);

    public void Remove(T value)
    {
        if (IsEmpty)
            return;

        if (_head!.Data?.Equals(value) ?? false)
        {
            _head = _head.Next;
            return;
        }

        var current = _head;
        do
        {
            if (current.Next is null)
                return;

            if (current.Next!.Data?.Equals(value) ?? false)
            {
                current.Next = current.Next.Next;
                return;
            }

            current = current.Next;
        } while (current is not null);
    }

    public T? Find(Func<T, bool> predicate)
    {
        if (IsEmpty)
            return default;

        foreach (var value in this)
            if (predicate(value))
                return value;

        return default;
    }

    public bool Contains(Func<T, bool> predicate) => Find(predicate) is not null;
}