namespace CoreAlgorithms;

public class Algorithms
{
    public static int BinarySearch(int[] arr, int val) //Specifically used to find the index of a certain element in a sorted array if it exists.
    {
        Array.Sort(arr);
        int low = 0, high = arr.Length - 1;
        int mid = (low+high)/2;
        
        while (low <= high)
        {
            if (arr[mid] == val)
                return mid;
            
            else if (arr[mid] < val)
                low = mid + 1;
            else
                high = mid - 1;
                
            mid = (low + high) / 2;
        }
        return -1;

    }
}