namespace Day7;

public interface PcItem
{
    public string Name { get; set; }
    public Directory Parent { get; set; }
}