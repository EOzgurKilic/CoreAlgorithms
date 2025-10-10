namespace CoreAlgorithms;

class Program
{
    static void Main(string[] args)
    {
        //BinarySearch
        /*int[] numbers = {1, 3, 5, 6, 7, 8, 8, 9, 5};
        Console.WriteLine(Algorithms.BinarySearch(numbers, 0));*/
        int[] arr = new int[]{5,2,3,1};
        Algorithms.SortArray(arr);
        foreach (int i in arr)
        {
            Console.WriteLine(i);
        }

    }
}