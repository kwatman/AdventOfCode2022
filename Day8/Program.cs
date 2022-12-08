using System;

namespace Day8 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines =  File.ReadAllLines("./input.txt");
            List<List<Tree>> trees = new List<List<Tree>>();
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    Tree tree = new Tree();
                    tree.Height = Int32.Parse(lines[y][x].ToString());
                    if (trees.Count < y || y == 0)
                    {
                        trees.Add(new List<Tree>());
                    }
                    trees[y].Add(tree);
                }
            }
            
            int treesVisible = 0;
            for (int y = 0; y < trees.Count; y++)
            {
                for (int x = 0; x < trees[y].Count; x++)
                {
                    //check left
                    bool leftVisible = true;
                    for (int l = x -1; l >= 0; l--)
                    {
                        if (y == 1 && x ==1)
                        {
                            Console.WriteLine("stop");
                        }
                        if (trees[y][l].Height >= trees[y][x].Height)
                        {
                            leftVisible = false;
                        }
                    }
                    
                    //check right
                    bool rightVisible = true;
                    for (int r = x + 1; r < trees[y].Count; r++)
                    {
                        if (trees[y][r].Height >= trees[y][x].Height)
                        {
                            rightVisible = false;
                        }
                    }

                    //check up
                    bool upVisible = true;
                    for (int u = y - 1; u >= 0; u--)
                    {
                        if (trees[u][x].Height >= trees[y][x].Height)
                        {

                            upVisible = false;
                        }
                    }

                    //check down
                    bool downVisible = true;
                    for (int d = y + 1; d < trees.Count; d++)
                    {
                        if (trees[d][x].Height >= trees[y][x].Height)
                        {
                            downVisible = false;
                        }
                    }

                    trees[y][x].Visible = (leftVisible || rightVisible || upVisible || downVisible);
                    if (trees[y][x].Visible)
                    {
                        treesVisible += 1;
                    }
                }
            }
            
            Console.WriteLine("there are " + treesVisible + " trees visible outside of the grid");
        }
    }
}