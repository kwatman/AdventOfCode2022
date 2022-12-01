namespace Day1;

public class Elf
{
    public List<long> Callories { get; set; }
    public long MaxCallories
    {
        get
        {
            long total = Callories.Sum(x=> x);
            return total;
        }
    }
    public Elf()
    {
        Callories = new List<long>();
    }
}