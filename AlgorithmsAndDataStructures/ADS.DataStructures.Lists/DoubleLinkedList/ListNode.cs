namespace ADS.DataStructures.Lists.DoubleLinkedList;

internal record ListNode<T>(T Data)
{
    public ListNode<T>? Next { get; set; }
    
    public ListNode<T>? Prev { get; set; }
}