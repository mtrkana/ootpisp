using System;
using System.Collections.Generic;
using System.IO;
using oop_3.Models;

namespace oop_3.Serialization
{
    public class TextSerializer
    {
        // Словарь фабрик. Ключ - имя класса в текстовом файле.
        // Использование словаря заменяет if-else / switch-case конструкции.
        private readonly Dictionary<string, IShapeFactory> _factories = new Dictionary<string, IShapeFactory>();

        public TextSerializer()
        {
            // Регистрация фабрик для известных классов фигуг
            _factories.Add("Point2D", new Point2DFactory());
            _factories.Add("Circle", new CircleFactory());
            _factories.Add("Rectangle", new RectangleFactory());
            _factories.Add("Square", new SquareFactory());
            _factories.Add("Triangle", new TriangleFactory());
            _factories.Add("Ring", new RingFactory());
        }

        // Метод для динамической регистрации новых классов извне (выполнение OCP - Open/Closed Principle)
        public void RegisterFactory(string className, IShapeFactory factory)
        {
            if (!_factories.ContainsKey(className))
                _factories.Add(className, factory);
        }

        // Сериализация списка объектов в текстовый файл
        public void Serialize(string filePath, List<Shape> shapes)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var shape in shapes)
                {
                    writer.WriteLine(shape.Serialize());
                }
            }
        }

        // Десериализация списка объектов из текстового файла
        public List<Shape> Deserialize(string filePath)
        {
            List<Shape> shapes = new List<Shape>();

            if (!File.Exists(filePath)) return shapes;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Разделяем строку по символу '|'
                    string[] parts = line.Split('|');
                    string className = parts[0];

                    // Ищем фабрику в словаре БЕЗ if-else
                    if (_factories.TryGetValue(className, out IShapeFactory factory))
                    {
                        Shape shape = factory.Create(parts);
                        shapes.Add(shape);
                    }
                }
            }
            return shapes;
        }
    }
}