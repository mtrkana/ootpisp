public class CircleFactory : IShapeFactory
{
    public IShape Create(Point a, Point b) => new CircleShape(a, b);
}