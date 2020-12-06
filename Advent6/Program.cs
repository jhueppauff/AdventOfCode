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
            List<int> countOfAnsweres = new List<int>();

            foreach (string group in groups)
            {
                countOfAnsweres.Add(group.Replace("\r\n", "").Distinct().Count());
            }

            int result = 0;

            foreach (int count in countOfAnsweres)
            {
                result += count;
            }

            Console.WriteLine($"Result {result}");
        }
    }
}
