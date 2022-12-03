using System;

namespace Day3 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxPrios = File.ReadAllLines("./input.txt")
                .Select(l => new string[] {l.Substring(0,l.Length/2),l.Substring(l.Length/2,l.Length/2)})
                .Select(a => (char.ToUpper(a[0].ToCharArray().ToList().Where(c => a[1].Contains(c)).ToList()[0]) - 64)+ (Char.IsUpper(a[0].ToCharArray().ToList().Where(c => a[1].Contains(c)).ToList()[0]) ?  26 :  0)).
                Sum();
            Console.WriteLine("result: " + maxPrios);
        }
    }
}