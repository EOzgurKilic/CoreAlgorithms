namespace CoreAlgorithms;

class Program
{
    static void Main(string[] args)
    {
        //BinarySearch
        /*int[] numbers = {1, 3, 5, 6, 7, 8, 8, 9, 5};
        Console.WriteLine(Algorithms.BinarySearch(numbers, 0));*/
        int[] arr = new int[]{8,2,5,3,9,4,7,6,1};
        Algorithms.QuickSort(arr);
        foreach (var VARIABLE in arr)
        {
            Console.WriteLine(VARIABLE);
        }
    }
}