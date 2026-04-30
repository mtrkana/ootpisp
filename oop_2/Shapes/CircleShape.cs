using System.Drawing;

public class CircleShape : IShape
{
    private Point a, b;

    public CircleShape(Point a, Point b)
    {
        this.a = a;
        this.b = b;
    }

    public Rectangle GetBounds()
    {
        int size = Math.Min(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));

        return new Rectangle(a.X, a.Y, size, size);
    }
}