using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Of_Rotations_SortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = new List<int>();
            input.Add(7);
            input.Add(8);
            input.Add(9);
            input.Add(1);
            input.Add(2);
            input.Add(3);
            input.Add(4);
            input.Add(5);
            input.Add(6);

            Console.WriteLine("Array is rotated " + findRotationCount(input) + " time(s)");//Time Complexity : O(n)         //(Using linear search)
            Console.WriteLine("Array is rotated " + findRotationCount2(input) + " time(s)");//Time Complexity : O(Log n)    //(Efficient Using Binary Search)
        }
        
        static int findRotationCount(List<int> arr)
        {
            int len = arr.Count;
            int low = 0, high = len - 1;
            return findRotations(arr, low, high);
        }
        static int findRotations(List<int> arr, int low, int high)
        {
            if (arr[low] <= arr[high])
                return low;
            int len = arr.Count;
            int mid = (low + high) / 2;
            int prev = (mid - 1 + len) % len; //if mid is at 0, consider last element as previous
            int next = (mid + 1) % len; // if mid is the last element, consider next element as the first

            if (arr[mid] < arr[prev] && arr[mid] < arr[next])
                return mid;

            if (arr[low] <= arr[mid]) // if left half is sorted, search in the right half
                return findRotations(arr, mid + 1, high);
            else
                return findRotations(arr, low, mid - 1); // search in the right half
        }


        static int findRotationCount2(List<int> arr)
        {
            int low = 0, high = arr.Count - 1;

            while ( arr[low] > arr[high] )
            {
                int mid = (high + low) / 2; //int mid = low + (high - low) / 2;
                if( arr[mid] > arr[high] )
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }
        static int findRotateCount(List<int> arr, int low, int high)
        {
            if (arr[low] > arr[high])
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] > arr[high])
                    return findRotateCount(arr, mid + 1, high);
                else
                    return findRotateCount(arr, low, mid);
            }
            else
                return low;
        }
    }
}


/*
 
     http://www.geeksforgeeks.org/find-rotation-count-rotated-sorted-array/

    Average Difficulty : 2/5.0
Based on 1 vote(s)
     
     */
