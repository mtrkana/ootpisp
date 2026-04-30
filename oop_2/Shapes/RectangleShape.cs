using System.Drawing;

public class RectangleShape : IShape
{
    private Point a, b;

    public RectangleShape(Point a, Point b)
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
}