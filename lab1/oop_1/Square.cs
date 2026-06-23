using System.Drawing;

public class Square : Shape
{
    int x, y, size;

    public Square(int x, int y, int size)
    {
        this.x = x;
        this.y = y;
        this.size = size;
    }

    public override void Draw(Graphics g)
    {
        g.DrawRectangle(Pens.Orange, x, y, size, size);
    }
}