namespace ADS.DataStructures.Lists;

internal record ListNode<T>(T Data)
{
    public ListNode<T>? Next { get; set; } = null;
}