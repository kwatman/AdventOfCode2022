using System;

namespace Day7 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines =  File.ReadAllLines("./input.txt");
            Directory root = new Directory() { Name = "/" };
            Directory currentDirectory = root;
            int i = -1;
            foreach (string line in lines)
            {
                i++;
                string[] lineParts = line.Split(" ");
                if (lineParts[0] == "$")
                {
                    switch (lineParts[1])
                    {
                        case "cd":
                            if (lineParts[2] == "/")
                            {
                                currentDirectory = root;
                            }
                            else if (lineParts[2] == "..")
                            {
                                Console.WriteLine("cd up to " + currentDirectory.Parent.Name + " from " + currentDirectory.Name);
                                currentDirectory = currentDirectory.Parent;
                            }
                            //else if (lineParts[2] != currentDirectory.Name && currentDirectory.FindSubDirectory(lineParts[2]) == null)
                            //{
                            //    Directory newDirectory = new Directory() { Name = lineParts[2], Parent = currentDirectory};
                            //    currentDirectory.Children.Add(newDirectory);
                            //    currentDirectory = newDirectory;
                            //}
                            else
                            {
                                currentDirectory = currentDirectory.FindSubDirectory(lineParts[2]);
                                Console.WriteLine("cd into " + currentDirectory.Name);
                            }
                            break;
                    }
                }
                else if(lineParts[0] == "dir" )
                {
                    if (currentDirectory.FindSubDirectory(lineParts[1]) == null)
                    {
                        Directory newDirectory = new Directory() { Name = lineParts[1], Parent = currentDirectory};
                        currentDirectory.Children.Add(newDirectory);
                    }
                }
                else
                {
                    PcFile file = new PcFile() { Name = lineParts[1],Parent = currentDirectory,Size = long.Parse(lineParts[0])};
                    currentDirectory.Children.Add(file);
                }
            }

            List<Directory> maxDirs = new List<Directory>();
            root.GetSize(ref maxDirs);
            Console.WriteLine("Total sum of size from directories with a total size of >=10000: " + maxDirs.Sum(d => d.GetSize()));

            long maxSpace = 70000000;
            long neededSpace = 30000000;
            long usedSpace = root.GetSize();
            List<Directory> eligibleForRemove = new List<Directory>();
            root.FindEligibleDirsToRemove(ref eligibleForRemove,maxSpace,neededSpace,usedSpace);
            Console.WriteLine("Best dir to remove has a size of: " + eligibleForRemove.Min(d => d.GetSize()));

        }
    }
}