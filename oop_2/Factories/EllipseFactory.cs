public class EllipseFactory : IShapeFactory
{
    public IShape Create(Point a, Point b) => new EllipseShape(a, b);
}