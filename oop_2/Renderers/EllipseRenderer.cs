using System.Drawing;


public class EllipseRenderer : IShapeRenderer
{
    public void Draw(Graphics g, IShape shape)
        => g.DrawEllipse(Pens.Blue, shape.GetBounds());
}
