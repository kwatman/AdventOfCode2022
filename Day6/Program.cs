using System;

namespace Day6 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
             string[] read = File.ReadAllLines("./input.txt");
             string input = read[0];
             Queue<Char> buffer = new Queue<char>();
             int bufferSize = 14;
             int startOfPacket = 0;
             for (int i = 0; i < input.Length; i++)
             {
                 buffer.Enqueue(input[i]);
                 if (buffer.Count > bufferSize)
                 {
                     buffer.Dequeue();
                 }
                 if (buffer.Count == bufferSize)
                 {
                     Dictionary<char, int> occurrences = new Dictionary<char, int>();
                     foreach (char c in buffer)
                     {
                         bool foundOccurence = false;
                         foreach (KeyValuePair<char,int> occurrence in occurrences)
                         {
                             if (occurrence.Key == c)
                             {
                                 occurrences[occurrence.Key] += 1;
                                 foundOccurence = true;
                             }
                         }
                         if (!foundOccurence)
                         {
                             occurrences.Add(c,1);
                         }
                     }

                     if (!occurrences.Any(c => c.Value > 1))
                     {
                         startOfPacket = i + 1;
                         break;
                     }
                 }
             }
            Console.WriteLine("Amount of characters read before start-of-packet: " + startOfPacket);
        }
    }
}