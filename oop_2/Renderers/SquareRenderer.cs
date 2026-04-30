using System.Drawing;

public class SquareRenderer : IShapeRenderer
{
    public void Draw(Graphics g, IShape shape)
        => g.DrawRectangle(Pens.Green, shape.GetBounds());
}
