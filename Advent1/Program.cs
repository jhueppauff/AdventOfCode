using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent1
{
    class Program
    {
        static async Task Main()
        {
            string[] content = await File.ReadAllLinesAsync("data.txt").ConfigureAwait(false);
            List<int> numbers = new List<int>();
            List<int> findings = new List<int>();

            foreach (var item in content)
            {
                numbers.Add(Convert.ToInt32(item));
            }

            foreach (int number in numbers)
            {
                foreach (int secondNumber in numbers)
                {
                    int finding = numbers.SingleOrDefault(x => x + secondNumber + number == 2020);

                    if (finding != 0 && !findings.Any(x => x == finding))
                    {
                        findings.Add(finding);
                        Console.WriteLine(finding);
                    }
                }
            }

            int result = findings[0] * findings[1] * findings[2];

            Console.WriteLine($"Result : {result}");
        }
    }
}
