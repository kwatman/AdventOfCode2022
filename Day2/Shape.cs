namespace Day2;

public class Shape
{
    public static List<Shape> Shapes;
    public string Name { get; set; }
    public string OpponentAlias { get; set; }
    public string Alias { get; set; }
    public int Score { get; set; }
    
    public Shape Weakness { get; set; }

    public Shape(string name,int score,string opponentAlias,string alias)
    {
        Name = name;
        Score = score;
        OpponentAlias = opponentAlias;
        Alias = alias;
        Shapes.Add(this);
    }

    public static Shape GetShape(string shapeAlias)
    {
        foreach (Shape shape in Shapes)
        {
            if (shape.Alias == shapeAlias || shape.OpponentAlias == shapeAlias)
            {
                return shape;
            }
        }
        return null;
    }

}