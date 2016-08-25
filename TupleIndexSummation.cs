using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_Practice
{
    class TupleIndexSummation
    {
        //Given an array arr[] and a number num, list the indices of all the tuples in A[] whose summation equals num
       
       //Function to sstore the indices of values whose sum is equal to num.
        #region GetIndices
        public static ArrayList GetIndex(int[] arr, int num, out bool flag)
        {
            flag = false;
            int l = 0;
            int r = (arr.Length-1);
            //Using a collection to include commas to separate , We can also use List or directly pass an Array 
            // As ArrayLists tend to be impacting thee performance due to boxing and unboxing of variables. 
            //Intentionally added here for readability purpose
            ArrayList IndexList = new ArrayList();
            while (l < r)
            {
                if (arr[l] + arr[r] == num)
                {
                    IndexList.Add(Array.IndexOf(arr, arr[l]));
                    IndexList.Add(",");
                    IndexList.Add(Array.IndexOf(arr, arr[r]));
                    IndexList.Add(" ");
                    l++;
                    r--;
                    flag = true;
                }
                else if (arr[l] + arr[r] < num)
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
            return IndexList;
        }
        #endregion
        //Using the Merge sort to get an overall complexity of O(nlogn)
        // We can reduce the complexity to further O(n) if we know the range of numbers in the array 
        //We can use the Dictionary class at that point of time
        #region Sorting
        public static int[] MergeSorter(int[] numArr)
        {
            if (numArr.Length <=1)
            {
                return numArr;
            }
            int mid = (numArr.Length / 2);
            int[] left = new int[mid];
            int[] right = new int[numArr.Length - mid];
            Array.Copy(numArr, left, mid);
            Array.Copy(numArr, mid, right, 0, right.Length);
            left = MergeSorter(left);
            right = MergeSorter(right);
            return Merge(left, right);
           
        }
        private static int[] Merge(int[] left, int[] right)
        {
            List<int> leftList = left.OfType<int>().ToList();
            List<int> rightList = right.OfType<int>().ToList();
            List<int> result = new List<int>();

            while (leftList.Count > 0 || rightList.Count > 0)
            {
                if (leftList.Count > 0 && rightList.Count > 0)
                {
                    if (leftList[0] <= rightList[0])
                    {
                        result.Add(leftList[0]);
                        leftList.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(rightList[0]);
                        rightList.RemoveAt(0);
                    }
                }

                else if (leftList.Count > 0)
                {
                    result.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }
                else if (rightList.Count > 0)
                {
                    result.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }
            return result.ToArray();
        }
        #endregion
        
        // The Main Driver function
        #region MainFunction
        public static void Main(string [] args)
        {
            int[] arr = new int[6] { 23, 11, 12, 24, 33, 2 }; //2 11 12 23 24 33  
            int[] sortedArr = MergeSorter(arr);
            bool check;
            int num=35;
            ArrayList resultSet = GetIndex(sortedArr, num, out check);
            if (check)
            {
                foreach (object obj in resultSet)
                {
                    Console.Write(obj);
                }
            }
            else 
            {
                Console.WriteLine("There are no values whose summation is equal to the given number");
            }
            Console.ReadLine();
        }
        #endregion
    }
}
