using System.Collections.Generic;
using System.Drawing;

public class ShapeList
{
    private List<Shape> shapes = new List<Shape>();

    public void Add(Shape s)
    {
        shapes.Add(s);
    }

    public void DrawAll(Graphics g)
    {
        foreach (var s in shapes)
        {
            s.Draw(g); // полиморфизм
        }
    }
}