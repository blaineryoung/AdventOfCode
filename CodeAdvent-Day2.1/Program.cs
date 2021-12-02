using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CodeAdvent // Note: actual namespace depends on the project name.
{
    public class Program
    {
        // sliding window

        public static void Main(string[] args)
        {
            int increases = TrackPosition("input.txt");
            Console.WriteLine($"Total is {increases}");
        }

        public static int TrackPosition(string inputFile)
        {
            int horizontal = 0;
            int depth = 0;

            // tuple is horizontal, depth
            Dictionary<string, Tuple<int, int>> directions = new Dictionary<string, Tuple<int, int>>()
            {
                { "forward", new Tuple<int, int>(1, 0) },
                { "down", new Tuple<int, int>(0, 1) },
                { "up" , new Tuple<int, int>(0, -1) },
            };

            foreach (string line in System.IO.File.ReadLines(inputFile))
            {
                String[] tokens = line.Split(' ');
                Tuple<int, int> direction = directions[tokens[0]];
                horizontal = horizontal + (direction.Item1 * int.Parse(tokens[1]));
                depth = depth + (direction.Item2 * int.Parse(tokens[1]));
            }

            return horizontal * depth;
        }
    }
}
