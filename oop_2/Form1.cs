using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace oop_2
{
    public partial class Form1 : Form
    {
        // Список всех фигур (МОДЕЛЬ)
        private List<IShape> shapes = new List<IShape>();

        // Текущая рисуемая фигура
        private IShape currentShape;

        // Начальная точка
        private Point startPoint;

        // Словарь фабрик (вместо switch!)
        private Dictionary<string, IShapeFactory> factories;

        // Словарь отрисовщиков (вместо if!)
        private Dictionary<Type, IShapeRenderer> renderers;

        public Form1()
        {
            InitializeComponent();

            // Подключение обработчиков событий мыши
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;

            // Инициализация фабрик
            factories = new Dictionary<string, IShapeFactory>()
{
    { "Отрезок", new LineFactory() },
    { "Прямоугольник", new RectangleFactory() },
    { "Квадрат", new SquareFactory() },
    { "Круг", new CircleFactory() },
    { "Эллипс", new EllipseFactory() },
    { "Треугольник", new TriangleFactory() }
};

            // Инициализация отрисовщиков
            renderers = new Dictionary<Type, IShapeRenderer>()
{
    { typeof(LineShape), new LineRenderer() },
    { typeof(RectangleShape), new RectangleRenderer() },
    { typeof(SquareShape), new SquareRenderer() },
    { typeof(CircleShape), new CircleRenderer() },
    { typeof(EllipseShape), new EllipseRenderer() },
    { typeof(TriangleShape), new TriangleRenderer() }
};

            // Заполнение ComboBox
            comboBox1.Items.AddRange(new string[]
{
    "Отрезок",
    "Прямоугольник",
    "Квадрат",
    "Круг",
    "Эллипс",
    "Треугольник"
});
            comboBox1.SelectedIndex = 0;

            // Убираем мерцание
            this.DoubleBuffered = true;
        }

        // Нажатие мыши — начинаем рисовать
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;

            string type = comboBox1.SelectedItem.ToString();

            // Создание фигуры через фабрику
            currentShape = factories[type].Create(startPoint, startPoint);
        }

        // Движение мыши — изменяем размер фигуры
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentShape != null)
            {
                string type = comboBox1.SelectedItem.ToString();

                // Пересоздаем фигуру
                currentShape = factories[type].Create(startPoint, e.Location);

                Invalidate(); // перерисовка
            }
        }

        // Отпускание мыши — сохраняем фигуру
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentShape != null)
            {
                shapes.Add(currentShape);
                currentShape = null;
            }
        }

        // Отрисовка
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var shape in shapes)
                DrawShape(e.Graphics, shape);

            if (currentShape != null)
                DrawShape(e.Graphics, currentShape);
        }

        // Отрисовка через стратегию
        private void DrawShape(Graphics g, IShape shape)
        {
            var type = shape.GetType();

            if (renderers.ContainsKey(type))
            {
                renderers[type].Draw(g, shape);
            }
        }
    }
}