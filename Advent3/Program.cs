using System;
using System.IO;
using System.Threading.Tasks;

namespace Advent3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] content = await File.ReadAllLinesAsync("data.txt").ConfigureAwait(false);

            char tree = '#';

            Position position = new Position()
            {
                X = 0,
                Y = 0
            };

            int counter = 0;

            while (position.Y < content.Length - 1)
            {
                position = GetNewPosition(position);

                if (content[position.Y][position.X] == tree)
                {
                    counter++;
                }
            }

            Console.WriteLine($"Found {counter} trees");
        }

        private static Position GetNewPosition (Position currentPosition)
        {
            currentPosition.X += 3;
            currentPosition.Y += 1;

            if (currentPosition.X >= 31)
            {
                currentPosition.X -= 31;
            }

            return currentPosition;
        }
    }
}
