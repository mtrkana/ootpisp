using System;
using System.Drawing;
using System.Globalization;

namespace oop_3.Models
{
    // 5-й класс в иерархии: Треугольник
    public class Triangle : Shape
    {
        public override string ClassName => "Triangle";
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        // Конструкторы класса
        public Triangle() { SideA = 3; SideB = 4; SideC = 5; }

        // Текстовое представление свойств для UI
        public override string GetInfo() => $"A: {SideA}; B: {SideB}; C: {SideC}";

        // Обновление трех сторон из строки вида "A: 3; B: 4; C: 5"
        public override void UpdateFromInfo(string info)
        {
            var parts = info.Split(';');
            SideA = double.Parse(parts[0].Replace("A:", "").Trim(), CultureInfo.InvariantCulture);
            SideB = double.Parse(parts[1].Replace("B:", "").Trim(), CultureInfo.InvariantCulture);
            SideC = double.Parse(parts[2].Replace("C:", "").Trim(), CultureInfo.InvariantCulture);
        }

        // Сериализация объекта в строку
        public override string Serialize() => $"{ClassName}|{SideA.ToString(CultureInfo.InvariantCulture)}|{SideB.ToString(CultureInfo.InvariantCulture)}|{SideC.ToString(CultureInfo.InvariantCulture)}";

        // Сложная отрисовка треугольника по трем сторонам с центрированием
        public override void Draw(Graphics g, Pen pen, int x, int y)
        {
            double a = SideA * 5;
            double b = SideB * 5;
            double c = SideC * 5;

            // Если треугольник с такими сторонами невозможен — не рисуем его
            if (a + b <= c || a + c <= b || b + c <= a) return;

            // Математически рассчитываем локальные координаты трех вершин
            double x1 = 0;
            double y1 = 0;
            double x2 = c;
            double y2 = 0;

            double cosA = (b * b + c * c - a * a) / (2 * b * c);
            double sinA = Math.Sin(Math.Acos(cosA));

            double x3 = b * cosA;
            double y3 = b * sinA;

            // Находим геометрический центр (центроид) полученного треугольника
            double cenX = (x1 + x2 + x3) / 3;
            double cenY = (y1 + y2 + y3) / 3;

            // Переносим точки на реальный холст формы с учетом переданного центра (x, y)
            Point[] points = new Point[]
            {
                new Point(x + (int)(x1 - cenX), y - (int)(y1 - cenY)),
                new Point(x + (int)(x2 - cenX), y - (int)(y2 - cenY)),
                new Point(x + (int)(x3 - cenX), y - (int)(y3 - cenY))
            };

            // Соединяем точки линиями в замкнутый контур
            g.DrawPolygon(pen, points);
        }
    }
}