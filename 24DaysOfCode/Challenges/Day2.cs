using _24DaysOfCode.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _24DaysOfCode.Challenges
{
    public class Day2 : IAssigntment
    {
        List<int[]> data { get; set; }
        public void ReadData(string path)
        {
            data = [];
            foreach (var item in File.ReadLines(path))
            {
                var test = item.Trim().Split(" ").Select(x => Int32.Parse(x)).ToArray();
                data.Add(test);
            }
        }

        public void Solve(string path)
        {
            ReadData(path);
            Console.WriteLine(Challenge1());
            Console.WriteLine(Challenge2());

        }

        private int Challenge1()
        {
            int result = 0;
            foreach(var item in data)
            {
                bool isDecreasing = IsDecreasing(item);
                bool isIncreasing = IsIncreasing(item);
                bool distance = Distance(item);

                if(distance && !(isDecreasing == isIncreasing))
                    result++;
            }
            return result;
        }

        private int Challenge2()
        {
            int result = 0;
            List<int[]> maybeList= [];
            foreach (var item in data)
            {
                bool isDecreasing = IsDecreasing(item);
                bool isIncreasing = IsIncreasing(item);
                bool distance = Distance(item);

                if (distance && !(isDecreasing == isIncreasing))
                    result++;
                else maybeList.Add(item);
            }

            foreach (var item in maybeList)
            {
                var subsets = GetSubsets(item);
                foreach (var subset in subsets)
                {
                    bool isDecreasing = IsDecreasing(subset);
                    bool isIncreasing = IsIncreasing(subset);
                    bool distance = Distance(subset);

                    if (distance && !(isDecreasing == isIncreasing))
                    {
                        result++;
                        break;
                    }

                }
            }

            return result;
        }



        private bool Distance(int[] item)
        {
            for (int i = 0; i < item.Length - 1; i++)
            {
                if (Math.Abs(item[i] - item[i + 1]) > 3)
                    return false;
            }
            return true;
        }

        private bool IsIncreasing(int[] item)
        {
            for (int i = 0; i < item.Length - 1; i++)
            {
                if (item[i] >= item[i + 1]) 
                    return false;
            }
            return true; 
        }

        private bool IsDecreasing(int[] item)
        {
            for (int i = 0; i < item.Length - 1; i++)
            {
                if (item[i] <= item[i + 1]) 
                    return false;
            }
            return true;
        }

        public static List<int[]> GetSubsets(int[] inputArray)
        {
            List<int[]> subsets = new List<int[]>();

            // Generate subsets of length n-1 (length of inputArray - 1)
            for (int i = 0; i < inputArray.Length; i++)
            {
                // Create a new list excluding the element at index i
                List<int> subset = new List<int>();

                // Add elements except the one at index i
                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (j != i)
                    {
                        subset.Add(inputArray[j]);
                    }
                }

                // Add the subset to the result
                subsets.Add(subset.ToArray());
            }

            return subsets;
        }
    }
}
