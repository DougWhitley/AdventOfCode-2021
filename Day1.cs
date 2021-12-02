using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2021
{
    public class Day1
    {
        public static void Solve()
        {
            Console.WriteLine("Day 1");
            var testInput = ParseDay1Input(Inputs.Day1TestInput);
            var input = ParseDay1Input(Inputs.Day1Input);

            Console.WriteLine("Part 1 Test Solution: " + $"{Calculate(testInput)}");
            Console.WriteLine("Part 1 Solution: " + $"{Calculate(input)}");

            var testInputSum3 = testInput.Skip(2).Select((x, i) => testInput[i] + testInput[i + 1] + testInput[i + 2]).ToArray();
            var inputSum3 = input.Skip(2).Select((x, i) => input[i] + input[i + 1] + input[i + 2]).ToArray();

            Console.WriteLine("Part 2 Test Solution: " + $"{Calculate(testInputSum3)}");
            Console.WriteLine("Part 2 Solution: " + $"{Calculate(inputSum3)}");
            Console.WriteLine();
        }

        private static int[] ParseDay1Input(string input)
        {
            return input.Split('\n').Select(x => int.Parse(x)).ToArray();
        }

        private static int Calculate(int[] input)
        {
            return input.Where((x, i) => i > 0 && (x > input[i - 1])).Count();
        }
    }
}
