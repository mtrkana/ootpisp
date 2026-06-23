using System.Drawing;

public class EllipseShape : Shape
{
    int x, y, w, h;

    public EllipseShape(int x, int y, int w, int h)
    {
        this.x = x;
        this.y = y;
        this.w = w;
        this.h = h;
    }

    public override void Draw(Graphics g)
    {
        g.DrawEllipse(Pens.Green, x, y, w, h);
    }
}