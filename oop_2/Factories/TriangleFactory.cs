public class TriangleFactory : IShapeFactory
{
    public IShape Create(Point a, Point b) => new TriangleShape(a, b);
}