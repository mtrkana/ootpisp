using System.Drawing;

// Класс квадрата (всегда равные стороны)
public class SquareShape : IShape
{
    private Point a, b;

    // Конструктор
    public SquareShape(Point a, Point b)
    {
        // Определяем размер квадрата (берем максимальную сторону)
        int size = Math.Max(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));

        this.a = a;

        // Формируем квадрат с равными сторонами
        this.b = new Point(a.X + size, a.Y + size);
    }

    // Возвращает границы квадрата
    public Rectangle GetBounds()
    {
        return new Rectangle(
            Math.Min(a.X, b.X),
            Math.Min(a.Y, b.Y),
            Math.Abs(b.X - a.X),
            Math.Abs(b.Y - a.Y)
        );
    }
}