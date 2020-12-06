using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent6
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string content = await File.ReadAllTextAsync("data.txt").ConfigureAwait(false);

            string[] groups = content.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<int> countOfAnsweresA = new List<int>();

            foreach (string group in groups)
            {
                countOfAnsweresA.Add(group.Replace("\r\n", "").Distinct().Count());
            }

            int resultA = 0;

            foreach (int count in countOfAnsweresA)
            {
                resultA += count;
            }

            var resultB = content.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(group => group.Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                    .Select(person => person.ToCharArray())
                    .Aggregate<IEnumerable<char>>((prev, next) => prev.Intersect(next)).ToList())
                .Sum(x => x.Count);

            Console.WriteLine($"Result Part 1 {resultA}");
            Console.WriteLine($"Result Part 2 {resultB}");
        }
    }
}
