using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeAdvent // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int increases = CountIncreases("input.txt");
            Console.WriteLine($"Total is {increases}");
        }

        public static int CountIncreases(String inputFile)
        {
            int? lastSeen = null;
            int count = 0;

            foreach (string line in System.IO.File.ReadLines(inputFile))
            {
                int current = 0;
                if (false == int.TryParse(line, out current))
                {
                    throw new Exception($"Bad input {line}");
                }

                if (null != lastSeen && lastSeen < current)
                {
                    count++;
                }

                lastSeen = current;
            }

            return count;
        }
    }
}