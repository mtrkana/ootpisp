using System.Drawing;

public interface IShapeRenderer
{
    void Draw(Graphics g, IShape shape);
}