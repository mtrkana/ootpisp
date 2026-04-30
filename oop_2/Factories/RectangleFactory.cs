public class RectangleFactory : IShapeFactory
{
    public IShape Create(Point a, Point b) => new RectangleShape(a, b);
}