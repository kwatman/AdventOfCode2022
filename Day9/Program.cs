using System;

namespace Day9 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("./input.txt");
            List<Position> positions = new List<Position>();
            Position headPosition = new Position(0,0);
            Position tailPosition = new Position(0,0);
            for (int i = 0; i < lines.Length; i++)
            {
                string order = lines[i].Split(" ")[0];  
                int steps = Int32.Parse(lines[i].Split(" ")[1]);
                for (int j = 0; j < steps; j++)
                {
                    //Head pos
                    switch (order)
                    {
                        case "U":
                            headPosition.Y += 1;
                            break;
                        
                        case "D":
                            headPosition.Y -= 1;
                            break;

                        case "L":
                            headPosition.X -= 1;
                            break;
                        
                        case "R":
                            headPosition.X += 1;
                            break;
                    }
                    
                    
                    if(Math.Abs(headPosition.X - tailPosition.X) > 10)
                    {
                        tailPosition.X += (headPosition.X - tailPosition.X) >= 0 ? (headPosition.X - tailPosition.X) -1 : (headPosition.X - tailPosition.X) + 1;
                        if (tailPosition.Y != headPosition.Y)
                        {
                            tailPosition.Y = (headPosition.Y - tailPosition.Y) >= 0 ? -1 : + 1;
                        }
                    }else if(Math.Abs(headPosition.Y - tailPosition.Y) > 10)
                    {
                        tailPosition.Y += (headPosition.Y - tailPosition.Y) >= 0 ? (headPosition.Y - tailPosition.Y) -1 : (headPosition.Y - tailPosition.Y) + 1;
                        if (tailPosition.X != headPosition.X)
                        {
                            tailPosition.X = (headPosition.X - tailPosition.X) >= 0 ? -1 : + 1;
                        }
                    }

                    if (!positions.Any(pos => pos.X == tailPosition.X && pos.Y == tailPosition.Y))
                    {
                        Position position = new Position(tailPosition.X,tailPosition.Y);
                        positions.Add(position);
                    }
                }
            }
            
            Console.WriteLine("The tail visited " + positions.Count + " unique positions");
        }
        
    }
}