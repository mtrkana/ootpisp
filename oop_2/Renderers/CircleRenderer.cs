using System.Drawing;

public class CircleRenderer : IShapeRenderer


{
    public void Draw(Graphics g, IShape shape)
        => g.DrawEllipse(Pens.Black, shape.GetBounds());
}