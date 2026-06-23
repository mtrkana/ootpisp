using System;
using System.Drawing;
using System.Globalization;

namespace oop_3.Models
{
    // 2-й класс в иерархии: Круг
    public class Circle : Shape
    {
        public override string ClassName => "Circle";
        public double Radius { get; set; }

        // Конструкторы класса
        public Circle() { Radius = 1; }
        public Circle(double radius) { Radius = radius; }

        // Текстовое представление свойств для UI
        public override string GetInfo() => $"Радиус: {Radius}";

        // Обновление радиуса из UI
        public override void UpdateFromInfo(string info)
        {
            Radius = double.Parse(info.Replace("Радиус:", "").Trim(), CultureInfo.InvariantCulture);
        }

        // Сериализация объекта в строку
        public override string Serialize() => $"{ClassName}|{Radius.ToString(CultureInfo.InvariantCulture)}";

        // Отрисовка круга
        public override void Draw(Graphics g, Pen pen, int x, int y)
        {
            int r = (int)(Radius * 5); // Масштабируем радиус для видимости

            // Метод DrawEllipse принимает координаты верхнего левого угла описывающего квадрата
            g.DrawEllipse(pen, x - r, y - r, r * 2, r * 2);
        }
    }
}