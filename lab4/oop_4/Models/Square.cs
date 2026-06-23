using System;
using System.Drawing;
using System.Globalization;

namespace oop_3.Models
{
    // 4-й класс в иерархии: Квадрат (наследуется от Прямоугольника)
    public class Square : Rectangle
    {
        public override string ClassName => "Square";

        // Конструкторы класса (передают одинаковые значения в базовый класс прямоугольника)
        public Square() : base(1, 1) { }
        public Square(double side) : base(side, side) { }

        // Текстовое представление свойств для UI (показываем только одну сторону)
        public override string GetInfo() => $"Сторона: {Width}";

        // Обновление стороны из UI
        public override void UpdateFromInfo(string info)
        {
            double side = double.Parse(info.Replace("Сторона:", "").Trim(), CultureInfo.InvariantCulture);
            Width = side;
            Height = side;
        }

        // Сериализация объекта в строку
        public override string Serialize() => $"{ClassName}|{Width.ToString(CultureInfo.InvariantCulture)}";

        // Отрисовка квадрата
        public override void Draw(Graphics g, Pen pen, int x, int y)
        {
            // Так как у квадрата Width равен Height, мы можем полностью запустить
            // логику отрисовки родительского прямоугольника
            base.Draw(g, pen, x, y);
        }
    }
}