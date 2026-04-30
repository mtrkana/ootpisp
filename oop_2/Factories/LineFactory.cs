public class LineFactory : IShapeFactory
{
    public IShape Create(Point a, Point b) => new LineShape(a, b);
}