using System.Drawing;

public interface IShapeFactory
{
    IShape Create(Point a, Point b);
}