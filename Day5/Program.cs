using System;

namespace Day5 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Stack<Crate>> crates1 = movePart1(ParseCrates());
            List<Stack<Crate>> crates2 = movePart2(ParseCrates());
            Console.Write("Top row for part 1 is: ");
            foreach (Stack<Crate> crate in crates1)
            {
                Console.Write(crate.Peek().Name.Replace("[","").Replace("]",""));
            }

            Console.WriteLine("");
            Console.Write("Top row for part 2 is: ");
            foreach (Stack<Crate> crate in crates2)
            {
                Console.Write(crate.Peek().Name.Replace("[","").Replace("]",""));
            }
            
        }

        public static  List<Stack<Crate>> ParseCrates()
        {
            string[] lines = File.ReadAllLines("./input.txt");
            List<Stack<Crate>> platforms = new List<Stack<Crate>>(new Stack<Crate>[9]);
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }
                for (int i = 0; i < 9; i++)
                {
                    int loc = (i * 3) == 0 ? 0 : (i * 4);
                    if (line[loc] == '[')
                    {
                        if (platforms[i] == null)
                        {
                            platforms[i] = new Stack<Crate>();
                        }
                        platforms[i].Push(new Crate(line.Substring(loc,3)));
                    }
                }
            }

            for (int i = 0; i < platforms.Count; i++)
            {
                Stack<Crate> newStack = new Stack<Crate>();
                while (platforms[i].Count != 0)
                {
                    newStack.Push(platforms[i].Pop());
                }

                platforms[i] = newStack;
            }

            return platforms;
        }

        public static List<Stack<Crate>> movePart1(List<Stack<Crate>> crates)
        {
            string[] lines = File.ReadAllLines("./input.txt");
            bool foundstart = false;
            for (int i = 0; i < lines.Length; i++)
            {
                if (foundstart == false)
                {
                    if (string.IsNullOrEmpty(lines[i]))
                    {
                        foundstart = true;
                    }
                }
                else
                {
                    string[] line = lines[i].Split(" ");
                    int ammount = Int32.Parse(line[1]);
                    int from = Int32.Parse(line[3]);
                    int to = Int32.Parse(line[5]);
                    for (int a = 0; a < ammount; a++)
                    {
                        Crate crate = crates[from - 1].Pop();
                        crates[to -1].Push(crate);
                    } 
                }
            }

            return crates;
        }
        public static List<Stack<Crate>> movePart2(List<Stack<Crate>> crates)
        {
            string[] lines = File.ReadAllLines("./input.txt");
            bool foundstart = false;
            for (int i = 0; i < lines.Length; i++)
            {
                if (foundstart == false)
                {
                    if (string.IsNullOrEmpty(lines[i]))
                    {
                        foundstart = true;
                    }
                }
                else
                {
                    string[] line = lines[i].Split(" ");
                    int ammount = Int32.Parse(line[1]);
                    int from = Int32.Parse(line[3]);
                    int to = Int32.Parse(line[5]);
                    Stack<Crate> toMove = new Stack<Crate>();
                    for (int a = 0; a < ammount; a++)
                    {
                        toMove.Push(crates[from - 1].Pop());
                    }
                    while (toMove.Count != 0)
                    {
                        crates[to -1].Push(toMove.Pop());
                    }
                }
            }

            return crates;
        }
    }
}