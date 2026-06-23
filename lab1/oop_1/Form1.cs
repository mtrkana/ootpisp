using System;
using System.Drawing;
using System.Windows.Forms;

namespace oop_1
{
    public partial class Form1 : Form   
    {
        private ShapeList shapeList = new ShapeList();

        public Form1()
        {
            InitializeComponent();

            shapeList.Add(new Line(10, 10, 200, 50));
            shapeList.Add(new RectangleShape(50, 70, 100, 60));
            shapeList.Add(new Circle(200, 100, 40));
            shapeList.Add(new EllipseShape(300, 50, 120, 60));
            shapeList.Add(new Triangle(
                new Point(100, 200),
                new Point(150, 300),
                new Point(50, 300)
            ));
            shapeList.Add(new Square(250, 200, 80));

            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            shapeList.DrawAll(e.Graphics);
        }
    }
}