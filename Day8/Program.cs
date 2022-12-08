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
            int highestRating = 0;
            for (int y = 0; y < trees.Count; y++)
            {
                for (int x = 0; x < trees[y].Count; x++)
                {
                    //check left
                    bool leftVisible = true;
                    int leftViewDistance = 0;
                    for (int l = x -1; l >= 0; l--)
                    {
                        if (trees[y][l].Height >= trees[y][x].Height && leftVisible)
                        {
                            leftVisible = false;
                            leftViewDistance = x - l;
                        }
                    }
                    if (leftVisible)
                    {
                        leftViewDistance = x - 0;
                    }
                    
                    //check right
                    bool rightVisible = true;
                    int rightViewDistance = 0;
                    for (int r = x + 1; r < trees[y].Count; r++)
                    {
                        if (trees[y][r].Height >= trees[y][x].Height && rightVisible)
                        {
                            rightVisible = false;
                            rightViewDistance = r - x;
                        }
                    }
                    if (rightVisible)
                    {
                        rightViewDistance = (trees.Count -1) - x;
                    }

                    //check up
                    bool upVisible = true;
                    int upViewDistance = 0;
                    for (int u = y - 1; u >= 0; u--)
                    {
                        if (y == 1 && x ==1)
                        {
                            Console.WriteLine("stop");
                        }
                        if (trees[u][x].Height >= trees[y][x].Height && upVisible)
                        {

                            upVisible = false;
                            upViewDistance = y - u;
                        }
                    }
                    if (upVisible)
                    {
                        upViewDistance = y - 0;
                    }

                    //check down
                    bool downVisible = true;
                    int downViewDistance = 0;
                    for (int d = y + 1; d < trees.Count; d++)
                    {
                        if (trees[d][x].Height >= trees[y][x].Height && downVisible)
                        {
                            downVisible = false;
                            downViewDistance = d - y;
                        }
                    }
                    if (downVisible)
                    {
                        downViewDistance = (trees.Count -1) - y;
                    }

                    trees[y][x].Visible = (leftVisible || rightVisible || upVisible || downVisible);
                    trees[y][x].ViewRating = leftViewDistance * rightViewDistance * upViewDistance * downViewDistance;
                    if (trees[y][x].Visible)
                    {
                        treesVisible += 1;
                    }

                    if (highestRating < trees[y][x].ViewRating)
                    {
                        highestRating = trees[y][x].ViewRating;
                    }
                }
            }
            
            Console.WriteLine("there are " + treesVisible + " trees visible outside of the grid");
            Console.WriteLine("the highest view rating is: " + highestRating);
        }
    }
}