using System;

namespace Day3 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxPrios = File.ReadAllLines("./input.txt").Select(l =>
                {
                    string first = l.Substring(0,l.Length/2);
                    string last = l.Substring(l.Length/2,l.Length/2);
                    string[] parts = { first, last };
                    return parts;
                }).Select(a =>
                {
                   char item = a[0].ToCharArray().ToList().Where(c => a[1].Contains(c)).ToList()[0];
                   int prior = (char.ToUpper(item) - 64)+ (Char.IsUpper(item) ?  26 :  0);
                   return prior;
                }).Sum();
            Console.WriteLine("result: " + maxPrios);
        }
    }
}