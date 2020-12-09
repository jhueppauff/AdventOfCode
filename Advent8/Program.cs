using System;
using System.IO;
using System.Threading.Tasks;

namespace Advent8
{
    class Program
    {
        static bool[] visited;
        static bool isTerminated = false;

        static async Task Main(string[] args)
        {
            string[] content = await File.ReadAllLinesAsync("data.txt").ConfigureAwait(false);
            visited = new bool[content.Length];

            Console.WriteLine("PartA: {0}", ExecuteProgram(content));
            Console.WriteLine("PartB: {0}", PartB(content));
        }

        static int ExecuteProgram(string[] instructions)
        {
            int ip = 0;
            int accumulator = 0;
            string opCode = "";
            string instruction = "";
            bool[] visited = new bool[1000];

            while (true)
            {
                if (ip == instructions.Length)
                {
                    isTerminated = true;
                    return accumulator;
                }

                if (visited[ip] == true)
                    return accumulator;

                visited[ip] = true;

                string tmp = instructions[ip].ToString();
                string[] res = tmp.Split(null);
                instruction = res[0].ToString();
                opCode = res[1].ToString();

                if (instruction == "nop")
                {
                    ip++;
                }
                else if (instruction == "acc")
                {
                    ip++;

                    if (opCode[0].ToString() == "+")
                    {
                        accumulator = accumulator + int.Parse(opCode.Remove(0, 1).ToString());
                    }
                    else if (opCode[0].ToString() == "-")
                    {
                        accumulator = accumulator - int.Parse(opCode.Remove(0, 1).ToString());
                    }
                }
                else if (instruction == "jmp")
                {
                    if (opCode[0].ToString() == "+")
                    {
                        ip = ip + int.Parse(opCode.Remove(0, 1).ToString());
                    }
                    else if (opCode[0].ToString() == "-")
                    {
                        ip = ip - int.Parse(opCode.Remove(0, 1).ToString());
                    }
                }
            }
            return 0;
        }


        static int PartB(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                string[] cpyInput = new string[input.Length];
                Array.Copy(input, cpyInput, input.Length);
                int result = 0;

                if (cpyInput[i].Substring(0, 3) == "nop")
                {
                    Array.Copy(input, cpyInput, input.Length);
                    cpyInput[i] = cpyInput[i].Replace("nop", "jmp");
                    result = ExecuteProgram(cpyInput);
                }
                if (cpyInput[i].Substring(0, 3) == "jmp")
                {
                    Array.Copy(input, cpyInput, input.Length);
                    cpyInput[i] = cpyInput[i].Replace("jmp", "nop");
                    result = ExecuteProgram(cpyInput);

                }
                if (isTerminated)
                    return result;
            }
            return 0;

        }
    }
}
