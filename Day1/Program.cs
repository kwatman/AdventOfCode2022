namespace Day1;
class Program
{
    public static List<Elf> elfs { get; set; }
    static void Main(string[] args)
    {
        elfs = new List<Elf>();
        string[] lines = System.IO.File.ReadAllLines(@"./input.txt");
        long total = 0;
        Elf elf = new Elf();
        for(int i = 0; i < lines.Length; i++ )
        {
            if (!string.IsNullOrEmpty(lines[i]))
            {
                long calories = long.Parse(lines[i]);
                elf.Callories.Add(calories);
            }
            else
            {
                elfs.Add(elf);
                elf = new Elf();
            }
        }
        Console.WriteLine("The elf with the highest callories is: " + elfs.Max(e => e.MaxCallories));
        Console.WriteLine("The top 3 elfs with the highest callories is: " + elfs.OrderByDescending(x => x.MaxCallories).Take(3).Sum(e => e.MaxCallories));
    }
}