using System;
using System.Drawing;
using System.Globalization;

namespace oop_3.Models
{
    // 1-й класс в иерархии: Точка
    public class Point2D : Shape
    {
        public override string ClassName => "Point2D";
        public double X { get; set; }
        public double Y { get; set; }

        // Конструкторы класса
        public Point2D() { X = 0; Y = 0; }
        public Point2D(double x, double y) { X = x; Y = y; }

        // Возвращает свойства в виде строки для UI
        public override string GetInfo() => $"X: {X}; Y: {Y}";

        // Парсинг строки вида "X: 10; Y: 20" при редактировании в UI
        public override void UpdateFromInfo(string info)
        {
            var parts = info.Split(';');
            X = double.Parse(parts[0].Replace("X:", "").Trim(), CultureInfo.InvariantCulture);
            Y = double.Parse(parts[1].Replace("Y:", "").Trim(), CultureInfo.InvariantCulture);
        }

        // Сериализация объекта в строку
        public override string Serialize() => $"{ClassName}|{X.ToString(CultureInfo.InvariantCulture)}|{Y.ToString(CultureInfo.InvariantCulture)}";

        // Отрисовка: рисуем точку как маленький закрашенный кружок радиусом 3 пикселя
        public override void Draw(Graphics g, Pen pen, int x, int y)
        {
            // Сдвигаем точку относительно центра холста (умножаем на 5 для масштаба)
            int targetX = x + (int)(X * 5);
            int targetY = y - (int)(Y * 5); // В компьютерной графике ось Y направлена вниз, поэтому вычитаем

            using (var brush = new SolidBrush(pen.Color))
            {
                g.FillEllipse(brush, targetX - 3, targetY - 3, 6, 6);
            }
        }
    }
}