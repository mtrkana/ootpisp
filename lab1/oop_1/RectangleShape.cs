using System.Drawing;

public class RectangleShape : Shape
{
    int x, y, w, h;

    public RectangleShape(int x, int y, int w, int h)
    {
        this.x = x;
        this.y = y;
        this.w = w;
        this.h = h;
    }

    public override void Draw(Graphics g)
    {
        g.DrawRectangle(Pens.Blue, x, y, w, h);
    }
}