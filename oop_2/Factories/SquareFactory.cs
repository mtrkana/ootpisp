public class SquareFactory : IShapeFactory
{
    public IShape Create(Point a, Point b) => new SquareShape(a, b);
}