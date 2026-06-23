using System;
using System.Drawing;
using System.Globalization;

namespace oop_3.Models
{
    // 3-й класс в иерархии: Прямоугольник
    public class Rectangle : Shape
    {
        public override string ClassName => "Rectangle";
        public double Width { get; set; }
        public double Height { get; set; }

        // Конструкторы класса
        public Rectangle() { Width = 1; Height = 1; }
        public Rectangle(double width, double height) { Width = width; Height = height; }

        // Текстовое представление свойств для UI
        public override string GetInfo() => $"Ширина: {Width}; Высота: {Height}";

        // Обновление ширины и высоты из строки вида "Ширина: 10; Высота: 20"
        public override void UpdateFromInfo(string info)
        {
            var parts = info.Split(';');
            Width = double.Parse(parts[0].Replace("Ширина:", "").Trim(), CultureInfo.InvariantCulture);
            Height = double.Parse(parts[1].Replace("Высота:", "").Trim(), CultureInfo.InvariantCulture);
        }

        // Сериализация объекта в строку
        public override string Serialize() => $"{ClassName}|{Width.ToString(CultureInfo.InvariantCulture)}|{Height.ToString(CultureInfo.InvariantCulture)}";

        // Отрисовка прямоугольника ровно из центра холста
        public override void Draw(Graphics g, Pen pen, int x, int y)
        {
            int w = (int)(Width * 5);
            int h = (int)(Height * 5);

            // Считаем левый верхний угол так, чтобы центр прямоугольника совпал с точкой (x, y)
            g.DrawRectangle(pen, x - w / 2, y - h / 2, w, h);
        }
    }
}