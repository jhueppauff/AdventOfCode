using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Advent2
{
    class Program
    {
        static async Task Main()
        {
            string[] content = await File.ReadAllLinesAsync("data.txt").ConfigureAwait(false);
            List<PasswordProperty> passwordProperties = new List<PasswordProperty>();

            foreach (var item in content)
            {
                PasswordProperty passwordProperty = new PasswordProperty
                {
                    MinimumLength = Convert.ToInt32(item.Split('-')[0]),
                    MaximumLength = Convert.ToInt32(((item.Split('-')[1]).Split(' ')[0])),
                    Character = Convert.ToChar((item.Split(' ')[1]).Replace(":", "")),
                    Password = item.Split(' ')[2]
                };

                passwordProperties.Add(passwordProperty);
            }

            List<string> results = new List<string>();
            int i = 0;

            foreach (var passwordProperty in passwordProperties)
            {
                /*int countOfOccurence = passwordProperty.Password.Split(passwordProperty.Character).Length - 1;
                if (countOfOccurence <= passwordProperty.MaximumLength && countOfOccurence >= passwordProperty.MinimumLength)
                {
                    Console.WriteLine($"Found : {passwordProperty.Password}");
                    i++;
                }*/

                if (passwordProperty.Password[passwordProperty.MinimumLength - 1] == passwordProperty.Character && passwordProperty.Password[passwordProperty.MaximumLength - 1] != passwordProperty.Character 
                    || passwordProperty.Password[passwordProperty.MinimumLength - 1] != passwordProperty.Character && passwordProperty.Password[passwordProperty.MaximumLength - 1] == passwordProperty.Character)
                {
                    Console.WriteLine($"Found : {passwordProperty.Password}");
                    i++;
                }
            }

            Console.WriteLine($"Found total amount of {i} Passwords");
        }
    }
}
