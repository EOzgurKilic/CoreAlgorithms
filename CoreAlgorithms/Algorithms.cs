using System.Diagnostics.SymbolStore;
using System.Text;

namespace CoreAlgorithms;

public class Algorithms
{
    public static int
        BinarySearch(int[] arr,
            int val) //Specifically used to find the index of a certain element in a sorted array if it exists.
    {
        Array.Sort(arr);
        int low = 0, high = arr.Length - 1;
        int mid = (low + high) / 2;

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
        /*Bubble Sort is a simple comparison-based sorting algorithm.
        It repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order.
        This process is repeated until the list is sorted.*/
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

    public static void SelectionSort(int[] arr)
    {
        //Selection Sort divides the array into two parts:
        //-The sorted part (initially empty)
        //-The unsorted part (initially the whole array)
        //It repeatedly selects the minimum element from the unsorted part and swaps it with the first unsorted element.
        //Time Complexity: O(n^2) quadratic;
        //Space Complexity: Linear O(1)
        int temp = 0, minIndex = 0;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            minIndex = i;

            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            StringBuilder str = new StringBuilder();
            if (minIndex != i)
            {
                temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }

        // Mini-Exercise
        /*You are given an array of student scores out of 100.
        Use Selection Sort to sort the scores in descending order (highest to lowest).
        Return both the sorted array.
        Exp Input: int[] scores = { 78, 95, 62, 89, 55 };
        Expexted Output: Sorted: [95, 89, 78, 62, 55] */
        /*for (int i = arr.Length - 1; i > 0; i--)
        {
            minIndex = i;
            for (int j = i - 1; j >= 0; j--)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }*/
    }


    public static void InsertionSort(int[] arr)
    {
        //Insertion Sort builds the final sorted array one item at a time. It’s similar to how you might sort playing cards in your hand:
        //1.Start with the second card.
        //2.Compare it with the cards before it.
        //3."Insert" it into its correct position among the sorted ones.
        //4.Repeat for all cards.

        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;

            // Move elements greater than key to one position ahead
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            // Place key at its correct position
            arr[j + 1] = key;
        }


        //Mini Exercise
        /*You are given an array of integers representing a queue of people based on their arrival times.
        Sort the array in ascending order using Insertion Sort, and return the number of shifts that happened during the sorting process.*/
        //Exp Output: int[] arrivals = { 8, 4, 3, 7, 6 };
        //Expected Output: Sorted: [3, 4, 6, 7, 8] Shifts: 6
        /*int count = 0, temp = 0;
        int current = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            temp = arr[i];
            current = i - 1;
            while (current >= 0 && arr[current] > temp)
            {
                arr[current + 1] = arr[current];
                current--;
                count++;
            }

            arr[current + 1] = temp;
        }

        return count;*/
    }


    public static int[] QuickSort(int[] a)
    {
        Quick3Way(a, 0, a.Length - 1);
        return a;

        void Quick3Way(int[] a, int lo, int hi)
        {
            const int CUTOFF = 16;

            while (lo < hi)
            {
                // Small segment → Insertion Sort
                if (hi - lo + 1 <= CUTOFF)
                {
                    InsertionRange(a, lo, hi);
                    return; // this segment done
                }

                // --- Randomized pivot at a[lo] ---
                int p = lo + Random.Shared.Next(hi - lo + 1);
                Swap(a, lo, p);
                int pivot = a[lo];

                // --- Dutch National Flag (3-way) partition ---
                int lt = lo, i = lo + 1, gt = hi;
                while (i <= gt)
                {
                    int v = a[i];
                    if (v < pivot) Swap(a, lt++, i++);
                    else if (v > pivot) Swap(a, i, gt--);
                    else i++;
                }
                // Now: a[lo..lt-1] < pivot, a[lt..gt] == pivot, a[gt+1..hi] > pivot

                // --- Tail-recursion elimination: recurse on smaller side first ---
                if (lt - lo < hi - gt)
                {
                    Quick3Way(a, lo, lt - 1); // smaller left by recursion
                    lo = gt + 1; // continue loop on larger right
                }
                else
                {
                    Quick3Way(a, gt + 1, hi); // smaller right by recursion
                    hi = lt - 1; // continue loop on larger left
                }
            }
        }

        void InsertionRange(int[] a, int lo, int hi)
        {
            for (int i = lo + 1; i <= hi; i++)
            {
                int key = a[i], j = i - 1;
                while (j >= lo && a[j] > key)
                {
                    a[j + 1] = a[j];
                    j--;
                }

                a[j + 1] = key;
            }
        }

        void Swap(int[] a, int i, int j)
        {
            if (i == j) return;
            int t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }

    public int[] MergeSort(int[] nums)
    {
        MergeSort(nums, 0, nums.Length - 1);
        return nums;
    

        void MergeSort(int[] arr, int l, int r)
        {
            if (l == r) return;

            int m = (l + r) / 2;
            MergeSort(arr, l, m);
            MergeSort(arr, m + 1, r);
            Merge(arr, l, m, r);
        }

        void Merge(int[] arr, int L, int M, int R)
        {
            int[] left = arr[L..(M + 1)];
            int[] right = arr[(M + 1)..(R + 1)];
    
            int i = L, j = 0, k = 0;

            while (j < left.Length && k < right.Length)
            {
                if (left[j] <= right[k])
                {
                    arr[i++] = left[j++];
                }
                else
                {
                    arr[i++] = right[k++];
                }
            }

            while (j < left.Length)
            {
                arr[i++] = left[j++];
            }

            while (k < right.Length)
            {
                arr[i++] = right[k++];
            }
        }
    }

public static int BoyerMooreVoting(int[] nums)
    {
        /*
         The Boyer-Moore Voting Algorithm
         
         It’s a linear-time, constant-space algorithm for finding a majority element in a sequence — an element that appears more than half the time.\
         It doesn't count elements in full; instead, it uses a cancellation logic to narrow down to the likely winner.
         Think of it as an election simulator:
            -Every element "votes" for itself.
            -Opposing votes cancel each other out.
            -If one value has an actual majority, it survives the storm.
        It’s useful in any scenario where:
            -You expect a majority-like property
            -You need single-pass, low-memory processing
         */
        int potential = 0, counter = 0;
        foreach (int i in nums)
        {
            if(counter == 0){
                potential = i;
                counter++;
            }
            else
                counter += potential == i ? 1 : -1;
        }
        return potential;
    }

    public static int[] SortArray(int[] nums) {
        MergeSort(nums, 0, nums.Length-1);
        return nums;
        void MergeSort(int[] arr, int l, int r){
            if (l == r) return;

            int m = (r + l)/2;
            MergeSort(arr, l, m);
            MergeSort(arr, m + 1, r);
            Merge(arr, l, m, r);
        }
        void Merge(int[] arr, int l, int m, int r){
            int[] left = arr[l..(m+1)];
            int[] right = arr[(m+1)..(r + 1)];
            int pt = r;
            r = right.Length - 1;
            while(0 <= r){
                if(m >= l && arr[m] >= right[r])
                    arr[pt--] = arr[m--];
                else
                    arr[pt--] = right[r--];
            }
        }
    }

    public static int[] BucketSort(int[] nums, int k) //https://www.youtube.com/watch?v=YPTqKIgVk-k&t=2s
    {
         /*
        ALGORITHM: Bucket-based Top-K Frequent Elements

        INTUITION
        ---------
        - Count how many times each value appears (frequency).
        - Use an array of "buckets" where the index represents a frequency f, and each bucket
          holds all values that appear exactly f times.
        - The maximum possible frequency is nums.Length (all elements are equal), so we need
          nums.Length + 1 buckets (index 0 unused).
        - Walk buckets from highest frequency down to lowest and take values until we have k.

        WHEN TO USE
        -----------
        - You need the top-k frequent elements from a static array (single pass, no streaming).
        - n can be large and you want linear time on average/worst (vs sorting all pairs).
        - You can afford O(n) extra memory (dictionary + buckets).

        COMPLEXITY
        ----------
        => Total Time: O(n)
        => Space: O(n)

        STEP-BY-STEP
        ------------
        1) Count occurrences of each value in a Dictionary<int,int> (value -> count).
        2) Allocate buckets: List<int>[n + 1]; n = nums.Length.
        3) For each (value, count) pair, add the value to buckets[count].
        4) Iterate frequency from n down to 1:
           - If the bucket is not null, append its values to the result until we collect k items.
        */
        // 1) Count frequencies
        var freqMap = new Dictionary<int, int>();
        foreach (var x in nums)
        {
            if (freqMap.TryGetValue(x, out int c)) freqMap[x] = c + 1;
            else freqMap[x] = 1;
        }

        // 2) Buckets: index = frequency, value = list of numbers with that frequency
        var buckets = new List<int>[nums.Length];
        foreach (var kv in freqMap)
        {
            if(buckets[kv.Value - 1] == null) buckets[kv.Value - 1] = new List<int>();
            buckets[kv.Value - 1].Add(kv.Key);
        }
        

        // 3) Collect from highest frequency down
        var result = new int[k];
        int idx = 0;

        for (int f = buckets.Length - 1; f >= 0; f--)
        {
            var bucket = buckets[f];
            if (bucket == null) continue;

            // Add all values with this frequency until we fill k
            for (int i = 0; i < bucket.Count; i++)
            {
                result[idx++] = bucket[i];
                if (idx == k) return result; // early stop
            }
        }

        return result; // (Should be filled; loop above early-returns when idx == k)
    }
}
