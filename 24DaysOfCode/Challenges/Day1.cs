using _24DaysOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24DaysOfCode.Challenges
{
    public class Day1 : IAssigntment
    {
        List<int> list1 = [];
        List<int> list2 = [];
        public void ReadData(string path)
        {
            foreach (var item in File.ReadLines(path))
            {
                var split = item.Trim().Split(" ");

                list1.Add(Int32.Parse(split.First()));
                list2.Add(Int32.Parse(split.Last()));
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
            list1.Sort();
            list2.Sort();
            int sum = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                sum += Math.Abs(list1[i] - list2[i]);
            }
            return sum;
        }

        private int Challenge2()
        {
            Dictionary<int, int> Similarity = [];
            foreach (int item in list1)
            {
                Similarity[item] = list2.Count(x => x == item);
            }

            var sum = 0;

            foreach (var item in Similarity)
            {
                sum += item.Key * item.Value;
            }
            return sum;
        }
    }
}
