using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2021
{
    public class Day3
    {
        public static void Solve()
        {
            Console.WriteLine("Day 3");
            var testInput = ParseInput(Inputs.Day3TestInput);
            var input = ParseInput(Inputs.Day3Input);

            Console.WriteLine($"Part 1 Test Solution: {Calculate(testInput, 5)}");
            Console.WriteLine($"Part 1 Solution: {Calculate(input, 12)}");

            Console.WriteLine($"Part 2 Test Solution: {Calculate2(testInput, 5)}");
            Console.WriteLine($"Part 2  Solution: {Calculate2(input, 12)}");
        }

        private static int Calculate(InputFlag[] input, int width)
        {
            var mask = 1;
            var gammaRate = 0;

            foreach(var flag in (InputFlag[])Enum.GetValues(typeof(InputFlag)))
            {
                gammaRate |= (int)GetFlagPrevalance(input, flag);
            }

            for (int i = 0; i < width -1; ++i)
            {
                mask |= mask << 1;
            }

            var epsilonRate = (int)~gammaRate & mask;
            
            return gammaRate * epsilonRate;
        }

        private static int Calculate2(InputFlag[] input, int width)
        {
            var oxGenRating = 0;
            var co2ScrubRating = 0;

            var oxFiltered = input;
            var c02ScrubFiltered = input;
            var flags = Enum.GetValues<InputFlag>();

            for (int i = 0; i < width && (oxGenRating == 0 || co2ScrubRating == 0); ++i)
            {
                var flag = flags[width - i];
                if (oxGenRating == 0)
                {
                    oxFiltered = GetFlagPrevalance(oxFiltered, flag) == flag ? oxFiltered.Where(x => x.HasFlag(flag)).ToArray() : oxFiltered.Where(x => !x.HasFlag(flag)).ToArray();
                    if (oxFiltered.Length == 1)
                    {
                        oxGenRating = (int)oxFiltered.First();
                    }
                }
                if (co2ScrubRating == 0)
                {
                    c02ScrubFiltered = GetFlagPrevalance(c02ScrubFiltered, flag) == flag ? c02ScrubFiltered.Where(x => !x.HasFlag(flag)).ToArray() : c02ScrubFiltered.Where(x => x.HasFlag(flag)).ToArray();
                    if (c02ScrubFiltered.Length == 1)
                    {
                        co2ScrubRating = (int)c02ScrubFiltered.First();
                    }
                }
            }
            return oxGenRating * co2ScrubRating;
        }

        private static InputFlag GetFlagPrevalance(InputFlag[] input, InputFlag target)
        {
            return input.Where(x => x.HasFlag(target)).Count() >= input.Length / 2m ? target : InputFlag.ZeroVal;
        }

        private static InputFlag[] ParseInput(string input)
        {
            return input.Split('\n').Select(x => (InputFlag)Convert.ToInt32(x.Trim(),2)).ToArray();
        }
    }

    [Flags]
    internal enum InputFlag : int
    {
            One  = 2048,
            Two = 1024,
            Three = 512,
            Four = 256,
            Five = 128,
            Six = 64,
            Seven = 32,
            Eight = 16,
            Nine = 8,
            Ten = 4,
            Eleven = 2,
            Twelve = 1,
            ZeroVal = 0,
    }
}
