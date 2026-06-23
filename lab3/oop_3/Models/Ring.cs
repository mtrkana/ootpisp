using System;
using System.Drawing;
using System.Globalization;

namespace oop_3.Models
{
    // 6-й класс в иерархии: Кольцо
    public class Ring : Shape
    {
        public override string ClassName => "Ring";
        public double OuterRadius { get; set; }
        public double InnerRadius { get; set; }

        // Конструкторы класса
        public Ring() { OuterRadius = 5; InnerRadius = 3; }

        // Текстовое представление свойств для UI
        public override string GetInfo() => $"Внешний: {OuterRadius}; Внутренний: {InnerRadius}";

        // Обновление радиусов из строки вида "Внешний: 5; Внутренний: 3"
        public override void UpdateFromInfo(string info)
        {
            var parts = info.Split(';');
            OuterRadius = double.Parse(parts[0].Replace("Внешний:", "").Trim(), CultureInfo.InvariantCulture);
            InnerRadius = double.Parse(parts[1].Replace("Внутренний:", "").Trim(), CultureInfo.InvariantCulture);
        }

        // Сериализация объекта в строку
        public override string Serialize() => $"{ClassName}|{OuterRadius.ToString(CultureInfo.InvariantCulture)}|{InnerRadius.ToString(CultureInfo.InvariantCulture)}";

        // Отрисовка кольца (два круга с общим центром)
        public override void Draw(Graphics g, Pen pen, int x, int y)
        {
            int rOuter = (int)(OuterRadius * 5);
            int rInner = (int)(InnerRadius * 5);

            // Рисуем внешнюю окружность
            g.DrawEllipse(pen, x - rOuter, y - rOuter, rOuter * 2, rOuter * 2);

            // Рисуем внутреннюю окружность
            g.DrawEllipse(pen, x - rInner, y - rInner, rInner * 2, rInner * 2);
        }
    }
}