using _24DaysOfCode.Interfaces;
using System.Text.RegularExpressions;

namespace _24DaysOfCode.Challenges
{
    public class Day3 : IAssigntment
    {
        private string data { get; set; }
        private string pattern = @"mul\((\d+),(\d+)\)";

        public void ReadData(string path)
        {
            data = File.ReadAllText(path);
        }

        public void Solve(string path)
        {
            ReadData(path);
            Console.WriteLine(Challenge1(data));
            Console.WriteLine(Challenge2());
        }

        private int Challenge1(string data)
        {
            MatchCollection matches = Regex.Matches(data, pattern);

            int result = 0;
            // Extract and print numbers
            foreach (Match match in matches)
            {
                int number1 = Int32.Parse(match.Groups[1].Value); // First number
                int number2 = Int32.Parse(match.Groups[2].Value); // Second number
                result += number1 * number2;
            }
            return result;
        }

        private int Challenge2()
        {
            
            

            // Remove all occurrences of the pattern
            return 0;
        }
    }
}