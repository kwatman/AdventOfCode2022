namespace Day7;

public class Directory : PcItem
{
    public string Name { get; set; }
    public Directory Parent { get; set; }
    public List<PcItem> Children { get; set; }

    public Directory()
    {
        Children = new List<PcItem>();
    }
    
    public Directory FindSubDirectory(string name)
    {
        foreach (PcItem pcItem in Children)
        {
            if (pcItem.GetType() == typeof(Directory) && pcItem.Name == name)
            {
                return (Directory)pcItem;
            }
        }

        return null;
    }

    public long GetSize()
    {
        long total = 0;
        foreach (PcItem pcItem in Children)
        {
            if (pcItem.GetType() == typeof(Directory))
            {
                Directory dir = (Directory)pcItem;
                total += dir.GetSize();
            }
            if (pcItem.GetType() == typeof(PcFile))
            {
                PcFile file = (PcFile)pcItem;
                total += file.Size;
            }
        }
        
        return total;
    }
    public long GetSize(ref List<Directory> maxDirs)
    {
        long total = 0;
        foreach (PcItem pcItem in Children)
        {
            if (pcItem.GetType() == typeof(Directory))
            {
                Directory dir = (Directory)pcItem;
                total += dir.GetSize(ref maxDirs);
            }
            if (pcItem.GetType() == typeof(PcFile))
            {
                PcFile file = (PcFile)pcItem;
                total += file.Size;
            }
        }

        if (total <= 100000)
        {
            maxDirs.Add(this);
        }
        return total;
    }

    public void FindEligibleDirsToRemove(ref List<Directory> eligible,long maxSpace,long neededSpace,long usedSpace)
    {
        foreach (PcItem pcItem in Children)
        {
            if (pcItem.GetType() == typeof(Directory))
            { 
                Directory dir = (Directory)pcItem;
                if (maxSpace - (usedSpace - dir.GetSize()) > neededSpace)
                {
                    eligible.Add(dir);
                }
                dir.FindEligibleDirsToRemove(ref eligible,maxSpace, neededSpace, usedSpace);
            }
        }
    }
}