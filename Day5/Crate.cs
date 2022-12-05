namespace Day5;

public class Crate
{
    public string Name { get; set; }

    public Crate(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}