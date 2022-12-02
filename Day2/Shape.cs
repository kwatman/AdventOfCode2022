namespace Day2;

public class Shape
{
    public static List<Shape> Shapes;
    public string Name { get; set; }
    public string Alias { get; set; }
    public int Score { get; set; }
    
    public Shape Weakness { get; set; }

    public Shape(string name,int score,string alias)
    {
        Name = name;
        Score = score;
        Alias = alias;
        Shapes.Add(this);
    }

    public static Shape GetShape(string shapeAlias)
    {
        foreach (Shape shape in Shapes)
        {
            if (shape.Alias == shapeAlias)
            {
                return shape;
            }
        }
        return null;
    }
    public static Shape GetCorrectShape(Shape oppenentShape, string winCondition)
    {
        foreach (Shape shape in Shapes)
        {
            if (shape.Weakness == oppenentShape && winCondition == "X")
            {
                return shape;
            }
            if (shape == oppenentShape && winCondition == "Y")
            {
                return shape;
            }
            if (oppenentShape.Weakness == shape && winCondition == "Z")
            {
                return shape;
            }
        }
        return null;
    }

}