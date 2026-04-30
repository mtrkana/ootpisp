using System.Drawing;

public class LineRenderer : IShapeRenderer
{
    public void Draw(Graphics g, IShape shape)
    {
        LineShape l = (LineShape)shape;
        g.DrawLine(Pens.Black, l.A, l.B);
    }
}