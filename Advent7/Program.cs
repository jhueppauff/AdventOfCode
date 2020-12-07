using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent7
{
    class Program
    {
        static Dictionary<string, string> RuleDictionary;

        static async Task Main(string[] args)
        {
            string[] content = await  File.ReadAllLinesAsync("data.txt").ConfigureAwait(false);

            RuleDictionary = content.Select(str => str[0..^1].Replace(" bags", "").Replace(" bag", ""))
                                                                .ToDictionary(str => str.Split(" contain ")[0], str => str.Split(" contain ")[1]);

            Console.WriteLine(Part01());
            Console.WriteLine(Part02());
        }

        static int Part01()
        {
            var count = 0;
            foreach (var key in RuleDictionary.Keys)
            {
                if (IsShinyGold(key))
                    count++;
            }
            return count;
        }

        static bool IsShinyGold(string str)
        {
            if (RuleDictionary[str].Contains("shiny gold"))
                return true;
            else
            {
                foreach (var value in RuleDictionary[str].Split(", "))
                {
                    if (!value.Equals("no other"))
                    {
                        if (!IsShinyGold(value[2..]))
                            continue;
                        else
                            return true;
                    }
                }
            }
            return false;
        }

        static int Part02(string color = "shiny gold")
        {
            var totalBags = 0;
            foreach (var s in RuleDictionary[color].Split(", "))
            {
                if (!s.Equals("no other"))
                {
                    var num = Convert.ToInt32(s.Substring(0, 1));
                    totalBags += num + num * Part02(s[2..]);
                }
                else
                    break;
            }
            return totalBags;
        }
    }
}
