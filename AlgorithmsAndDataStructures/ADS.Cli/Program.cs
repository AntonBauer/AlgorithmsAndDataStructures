// See https://aka.ms/new-console-template for more information

var list = new ADS.DataStructures.Lists.List<int>
{
    1,
    3,
    5
};
PrintList(list);
    
list.Remove(4);
PrintList(list);

list.Remove(3);
PrintList(list);
list.Add(3);

var odd = list.Find(IsOdd);
Console.WriteLine($"First odd is {odd}");

Console.WriteLine($"Contains 4? {list.Contains(4)}");
Console.WriteLine($"Contains 3? {list.Contains(3)}");

static void PrintList<T>(ADS.DataStructures.Lists.List<T> list)
{
    Console.WriteLine("Some values:");
    foreach(var value in list)
        Console.WriteLine(value);
    
    Console.WriteLine();
}

static bool IsOdd(int value) => value % 2 == 1;