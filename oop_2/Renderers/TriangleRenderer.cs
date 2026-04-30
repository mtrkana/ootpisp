using System.Drawing;


public class TriangleRenderer : IShapeRenderer
{
    public void Draw(Graphics g, IShape shape)
    {
        Rectangle r = shape.GetBounds();

        Point p1 = new Point(r.Left + r.Width / 2, r.Top);
        Point p2 = new Point(r.Left, r.Bottom);
        Point p3 = new Point(r.Right, r.Bottom);

        g.DrawPolygon(Pens.Red, new[] { p1, p2, p3 });
    }
}
