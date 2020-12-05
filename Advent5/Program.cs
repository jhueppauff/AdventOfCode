using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Advent5
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            string[] content = await File.ReadAllLinesAsync("data.txt").ConfigureAwait(false);
            Console.WriteLine(Solve(content, Convert.ToBoolean(args[0])));
        }

        private static string Solve(string[] lines, bool part2 = false)
        {
            HashSet<int> ids = new HashSet<int>();

            int min = int.MaxValue;
            int max = 0;

            foreach (string line in lines)
            {
                // Convert to binary
                int id = ParseSeatNumber(line);
                ids.Add(id);

                // Search
                if (id < min)
                {
                    min = id;
                }

                if (id > max)
                {
                    max = id;
                }
            }

            if (!part2)
            {
                // find max number
                return max.ToString();
            }

            for (int i = min; i < max; i++)
            {
                if (!ids.Contains(i))
                {
                    return i.ToString();
                }
            }

            return "no answer";

        }

        private static int ParseSeatNumber(string input)
        {
            int value = 0;

            foreach (char character in input)
            {
                value <<= 1;
                value += ~character >> 2 & 1;
            }

            return value;
        }
    }
}
