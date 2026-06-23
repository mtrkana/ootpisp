using oop_3.Models;

namespace oop_3.Serialization
{
    // Интерфейс фабрики для создания объекта по массиву строк данных
    public interface IShapeFactory
    {
        Shape Create(string[] data);
    }

    // Реализации фабрик для каждого класса
    public class Point2DFactory : IShapeFactory
    {
        public Shape Create(string[] data) => new Point2D(double.Parse(data[1], System.Globalization.CultureInfo.InvariantCulture), double.Parse(data[2], System.Globalization.CultureInfo.InvariantCulture));
    }

    public class CircleFactory : IShapeFactory
    {
        public Shape Create(string[] data) => new Circle(double.Parse(data[1], System.Globalization.CultureInfo.InvariantCulture));
    }

    public class RectangleFactory : IShapeFactory
    {
        // Явно указываем пространство имен для нашего класса
        public Shape Create(string[] data) => new oop_3.Models.Rectangle(double.Parse(data[1], System.Globalization.CultureInfo.InvariantCulture), double.Parse(data[2], System.Globalization.CultureInfo.InvariantCulture));
    }

    public class SquareFactory : IShapeFactory
    {
        public Shape Create(string[] data) => new Square(double.Parse(data[1], System.Globalization.CultureInfo.InvariantCulture));
    }

    public class TriangleFactory : IShapeFactory
    {
        public Shape Create(string[] data) => new Triangle
        {
            SideA = double.Parse(data[1], System.Globalization.CultureInfo.InvariantCulture),
            SideB = double.Parse(data[2], System.Globalization.CultureInfo.InvariantCulture),
            SideC = double.Parse(data[3], System.Globalization.CultureInfo.InvariantCulture)
        };
    }

    public class RingFactory : IShapeFactory
    {
        public Shape Create(string[] data) => new Ring
        {
            OuterRadius = double.Parse(data[1], System.Globalization.CultureInfo.InvariantCulture),
            InnerRadius = double.Parse(data[2], System.Globalization.CultureInfo.InvariantCulture)
        };
    }
}