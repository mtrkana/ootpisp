using System.Drawing;

public class Circle : Shape
{
    int x, y, r;

    public Circle(int x, int y, int r)
    {
        this.x = x;
        this.y = y;
        this.r = r;
    }

    public override void Draw(Graphics g)
    {
        g.DrawEllipse(Pens.Red, x, y, r * 2, r * 2);
    }
}