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
            int increases = CountIncreases("input.txt", 3);
            Console.WriteLine($"Total is {increases}");
        }

        public static int CountIncreases(string inputFile, int windowSize)
        {
            int? lastSeen = null;
            int[] windows = new int[windowSize];
            int lineCount = 0;
            int count = 0;

            foreach (string line in System.IO.File.ReadLines(inputFile))
            {
                int windowIndex = lineCount % windowSize;
                Debug.Assert(lineCount >= windowIndex);

                int current = 0;
                if (false == int.TryParse(line, out current))
                {
                    throw new Exception($"Bad input {line}");
                }

                for (int i = 0; i < windowSize; i++)
                {
                    windows[i] += current;
                }

                if (lineCount >= windowSize - 1)
                {
                    // We've done at least one full sliding window, can now start calculating.

                    if (null != lastSeen && lastSeen < windows[windowIndex])
                    {
                        count++;
                    }

                    lastSeen = windows[windowIndex];
                }

                windows[windowIndex] = 0;
                lineCount++;
            }

            return count;
        }
    }
}
