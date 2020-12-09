using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Advent9
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] content = await File.ReadAllLinesAsync("data.txt").ConfigureAwait(false);

            Solve(content);
        }

        static void Solve(string[] input)
        {
            List<long> values = new List<long>();
            foreach (string s in input)
            {
                values.Add(long.Parse(s));
            }

            long nextNumber = 0;
            long part1 = 0;
            int invalidIndex = 0;
            List<long> sums = new List<long>();
            for (int next = 25; next < values.Count; next++)
            {
                nextNumber = values[next];
                sums.Clear();
                for (int min = next - 25; min < next - 1; min++)
                {
                    for (int counter = 1; counter < 25; counter++)
                    {
                        sums.Add(values[min] + values[min + counter]);
                    }
                }
                if (!sums.Contains(nextNumber))
                {
                    part1 = nextNumber;
                    invalidIndex = values.FindIndex(x => x == nextNumber);
                    break;
                }
            }

            sums.Clear();
            long part2 = 0;
            for (int minRange = 0; minRange < invalidIndex - 2; minRange++)
            {
                sums.Add(values[minRange]);
                for (int maxRange = minRange + 1; maxRange < invalidIndex; maxRange++)
                {
                    sums.Add(sums[^1] + values[maxRange]);
                    if (sums[^1] == part1)
                    {
                        long low = long.MaxValue;
                        long high = 0;
                        for (int i = minRange; i <= maxRange; i++)
                        {
                            if (values[i] < low)
                                low = values[i];
                            else if (values[i] > high)
                                high = values[i];
                        }
                        part2 = high + low;
                    }
                }
            }

            Console.WriteLine("Part 1: {0}", part1);
            Console.WriteLine("Part 2: {0}", part2);
        }
    }
}
