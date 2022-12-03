namespace Day2;
class Program
{
    static void Main(string[] args)
    {
        Shape.Shapes = new List<Shape>();
        Shape rock = new Shape("rock",1,"A");
        Shape paper = new Shape("paper",2,"B");
        Shape scissors = new Shape("scissors",3,"C");

        rock.Weakness = paper;
        paper.Weakness = scissors;
        scissors.Weakness = rock;
        
        string[] lines = System.IO.File.ReadAllLines(@"./input.txt");
        int totalScore = 0;
        foreach (string line in lines)
        {
            string[] selections = line.Split(" ");
            Shape opponentShape = Shape.GetShape(selections[0]);
            Shape shape = Shape.GetCorrectShape(opponentShape,selections[1]);
            if (opponentShape.Weakness == shape)
            {
                totalScore += 6;
                totalScore += shape.Score;
            }else if (shape.Weakness == opponentShape)
            {
                totalScore += shape.Score;
            }
            else if(shape == opponentShape)
            {
                totalScore += 3;
                totalScore += shape.Score;
            }
        }

        Console.WriteLine(totalScore);
    }
}
