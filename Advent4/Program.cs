using System;
using System.IO;
using System.Linq;

namespace Advent4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(File.ReadAllText("data.txt")
                .Split("\r\n\r", StringSplitOptions.RemoveEmptyEntries)
                .Where(o => o.Count(z => z == ':') == 8 || (o.Count(z => z == ':') == 7 && !o.Contains("cid")))
                .Count());
        }
    }
}
