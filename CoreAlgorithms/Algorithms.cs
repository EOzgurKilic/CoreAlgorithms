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

    #region Sliding Window Technique
    //Sliding Window Technique splits into two main types;
    
    //Don't forget that subarray is not the same thing as subset is!
    /*1. Subarray:
    - A subarray is a sequence of elements from the original array
    that are **contiguous** (i.e., appear next to each other).
    - Example: For [1, 2, 3, 4], valid subarrays include:
    [1, 2], [2, 3, 4], [3], [1, 2, 3, 4]
    - Invalid: [1, 3, 4] (elements are not side by side)

    2. Subsequence:
    - A subsequence is a sequence that can be derived from the array
        by **deleting some or no elements**, without changing the order.
    - Example: For [1, 2, 3, 4], valid subsequences include:
    [1, 3], [2, 4], [1, 2, 3, 4]
    - Invalid: [3, 1] (order is changed)

    3. Subset:
    - A subset is any selection of elements from the array,
    regardless of order or position.
    - Example: For [1, 2, 3], all subsets include:
    [], [1], [2], [1, 3], [2, 3], [1, 2, 3]
    - Subsets are used in combinatorics and set theory.*/
    
    //Fixed Size Sliding Window
    public static int SlidingWindowFixedSize(int[] nums, int k)
    {
        //The favorable usage time of this technique is when you need to find the maximum sum of any subarray of size k.
        //With brute force, it equals O(n^2) quadratic time complexity;
        /*for (int i = 0; i <= nums.Length - k; i++) {
            int sum = 0;
            for (int j = i; j < i + k; j++) {
                sum += nums[j]; // full re-sum every time
            }
            // check sum > max
        }*/
        
        //With fixed-sized sliding window technique, the complexity rate decreases to linear O(n) time.
        int window = 0, max = 0;
        for (int i = 0; i < k; i++) //First window initialization
        {
            window += nums[i];
        }
        max = window;
        //and now we start moving the window in the way the next element added-the first element subtracted;
        for (int i = k; i < nums.Length; i++)
        {
            window += nums[i]; //adding the next element;
            window -= nums[i - k]; //subtracting the initial element of the previous window from our new window;
            max = Math.Max(max, window); //keeping the highest numbers track.
        }
        return max;
    }
    
    //Dynamic Sliding Window
    public static int DynamicSlidingWindow(int[] nums, int target)
    {
        //Dynamic Sliding Window is used when you need to find the smallest/largest subarray/substring that satisfies a condition.
        //Classic Example Problem:
        //Find the length of the smallest subarray whose sum is ≥ target.
        //With brute force, it equals O(n^2) quadratic time complexity;
        /*int minLength = int.MaxValue;
        
        for (int start = 0; start < nums.Length; start++) {
            int sum = 0;
            for (int end = start; end < nums.Length; end++) {
                sum += nums[end];
                if (sum >= target) {
                    minLength = Math.Min(minLength, end - start + 1);
                    break; // no need to check longer subarrays
                }
            }
        }*/
        
        //With dynamic sliding window technique, the complexity rate decreases to linear O(n) time;
        int window = 0, left = 0, minLength = nums.Length;
        for (int right = 0; right < nums.Length; right++)
        {
            window += nums[right];
            while (window >= target)
            {
                minLength = Math.Min(minLength, right - left + 1);
                window -= nums[left++];
            }
        }

        return minLength;
    }
    #endregion

    public static void BubbleSort(int[] arr)
    {
        //Learn Bubble Sort to understand sorting. Don’t use it in production.
        //Complexity Rate: O(n^2) quadratic time
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

    }
}