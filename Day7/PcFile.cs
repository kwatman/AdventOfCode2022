namespace Day7;

public class PcFile : PcItem
{
    public string Name { get; set; }
    public long Size { get; set; }
    public Directory Parent { get; set; }
}