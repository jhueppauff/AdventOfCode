using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent3
{
    class Program
    {
        private static List<Slope> slopes = new List<Slope>();

        static async Task Main(string[] args)
        {
            string[] content = await File.ReadAllLinesAsync("data.txt").ConfigureAwait(false);

            char tree = '#';

            Position position = new Position()
            {
                X = 0,
                Y = 0
            };
            slopes.Add(new Slope()
            {
                X = 1,
                Y = 1
            });
            slopes.Add(new Slope()
            {
                X = 3,
                Y = 1
            });
            slopes.Add(new Slope()
            {
                X = 5,
                Y = 1
            });
            slopes.Add(new Slope()
            {
                X = 7,
                Y = 1
            });
            slopes.Add(new Slope()
            {
                X = 1,
                Y = 2
            });

            List<int> listOfCounters = new List<int>();

            foreach (var item in slopes)
            {
                int counter = 0;

                while (position.Y < content.Length - 1)
                {
                    position = GetNewPosition(position, item);

                    if (content[position.Y][position.X] == tree)
                    {
                        counter++;
                    }
                }

                listOfCounters.Add(counter);
                position.Y = 0; 
                position.X = 0;
            }

            double result = 1;
            foreach (var item in listOfCounters)
            {
                if (item != 0)
                {
                    result = result * item;
                }
            }

            Console.WriteLine($"Result: {result}");
        }

        private static Position GetNewPosition(Position currentPosition, Slope slope)
        {
            currentPosition.X += slope.X;
            currentPosition.Y += slope.Y;

            if (currentPosition.X >= 31)
            {
                currentPosition.X -= 31;
            }

            return currentPosition;
        }
    }
}
