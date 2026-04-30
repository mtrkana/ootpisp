using System.Drawing;

public class RectangleRenderer : IShapeRenderer
{
    public void Draw(Graphics g, IShape shape)
        => g.DrawRectangle(Pens.Black, shape.GetBounds());
}