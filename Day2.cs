using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2021
{
    public class Day2
    {
        public static void Solve()
        {
            Console.WriteLine("Day 2");
            var testInput = ParseDay2Input(Inputs.Day2TestInput);
            var input = ParseDay2Input(Inputs.Day2Input);

            Console.WriteLine("Part 1 Test Solution: " + $"{Calculate(testInput)}");
            Console.WriteLine("Part 1 Solution: " + $"{Calculate(input)}");

            Console.WriteLine("Part 2 Test Solution: " + $"{Calculate2(testInput)}");
            Console.WriteLine("Part 2 Solution: " + $"{Calculate2(input)}");
        }

        private static  Tuple<string, int>[] ParseDay2Input(string input)
        {
            return input.Split('\n').Select( x => new Tuple<string, int>(x.Split(' ')[0], int.Parse(x.Split(' ')[1]))).ToArray();
        }

        private static int Calculate(Tuple<string, int>[] input)
        {
            var x = input.Where(x => x.Item1 == "forward").Sum(x => x.Item2);
            var y = input.Where(x => x.Item1 != "forward").Sum(x => x.Item1 == "down" ? x.Item2 : -x.Item2);

            return x * y;
        }

        private static int Calculate2(Tuple<string, int>[] input)
        {
            var x = 0;
            var aim = 0;
            var y = 0;
            foreach (var t in input)
            {
                switch (t.Item1)
                {
                    case "down":
                        aim += t.Item2;
                        break;
                    case "up":
                        aim -= t.Item2;
                        break;
                    case "forward":
                        x += t.Item2;
                        y += aim * t.Item2;
                        break;
                }
            }

            return x * y;
        }
    }
}
