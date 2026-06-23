using System;
using System.Drawing;

namespace oop_3.Models
{
    // Абстрактный базовый класс для всех фигур
    public abstract class Shape
    {
        // Каждая фигура должна иметь имя (тип) для сериализации
        public abstract string ClassName { get; }

        // Абстрактные методы для получения и изменения свойств в виде строки (для UI без if-else)
        public abstract string GetInfo();
        public abstract void UpdateFromInfo(string info);

        // Метод сериализации: превращает объект в текстовую строку
        public abstract string Serialize();
        public abstract void Draw(Graphics g, Pen pen, int x, int y); // Полиморфный метод отрисовки
    }
}