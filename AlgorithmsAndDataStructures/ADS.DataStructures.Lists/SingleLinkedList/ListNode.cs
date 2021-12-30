namespace ADS.DataStructures.Lists.SingleLinkedList;

internal record ListNode<T>(T Data)
{
    public ListNode<T>? Next { get; set; } = null;
}