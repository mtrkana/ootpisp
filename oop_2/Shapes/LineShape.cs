using System.Drawing;

public class LineShape : IShape
{
    private Point a, b;

    public LineShape(Point a, Point b)
    {
        this.a = a;
        this.b = b;
    }

    public Rectangle GetBounds()
    {
        return new Rectangle(
            Math.Min(a.X, b.X),
            Math.Min(a.Y, b.Y),
            Math.Abs(a.X - b.X),
            Math.Abs(a.Y - b.Y)
        );
    }

    public Point A => a;
    public Point B => b;
}