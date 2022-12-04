using System;

namespace Day4 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalOverlaps =  File.ReadAllLines("./input.txt")
                .Select(l => l.Split(","))
                .Select(s => new int[][] {s[0].Split("-").Select(i => Int32.Parse(i)).ToArray(),s[1].Split("-").Select(i => Int32.Parse(i)).ToArray()})
                .Select(i => ((i[0][0] <= i[1][0] && i[0][1] >= i[1][1]) || (i[1][0] <= i[0][0] && i[1][1] >= i[0][1])) ? 1 : 0)
                .Sum();

            Console.WriteLine("The total number of overlaps is: " + totalOverlaps);
                
        }
    }
}