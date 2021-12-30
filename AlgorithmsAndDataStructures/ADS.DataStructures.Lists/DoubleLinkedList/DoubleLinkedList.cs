using System.Collections;
using ADS.DataStructures.Lists.Extensions;

namespace ADS.DataStructures.Lists.DoubleLinkedList;

public class DoubleLinkedList<T> : IEnumerable<T>
{
    private ListNode<T>? _head;
    private ListNode<T>? _tail;

    private bool IsEmpty => _head is null && _tail is null;

    public DoubleLinkedList()
    {
    }

    public DoubleLinkedList(T value) => Add(value);

    public DoubleLinkedList(IEnumerable<T> values) => AddRange(values);

    public void Add(T value) => AddFromHead(value);

    public void AddRange(IEnumerable<T> values) => values.ForEach(AddFromHead);
    
    public void AddFromHead(T value)
    {
        if (IsEmpty)
            _head = _tail = new ListNode<T>(value);

        var current = _head;
        while (current!.Next is not null)
            current = current.Next;

        _tail = current.Next = new ListNode<T>(value);
        _tail.Prev = current;
    }

    public void AddFromTail(T value)
    {
        if (IsEmpty)
            _head = _tail = new ListNode<T>(value);

        var current = _tail;
        while (current!.Prev is not null)
            current = current.Prev;

        _head = current.Prev = new ListNode<T>(value);
        _head.Next = current;
    }

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
}