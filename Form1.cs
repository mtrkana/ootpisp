using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using oop_3.Models;
using oop_3.Serialization;

// Разрешаем конфликт имен между нашей фигурой и системной структурой
using Rectangle = oop_3.Models.Rectangle;

namespace oop_3
{
    public partial class Form1 : Form
    {
        // Основной список объектов в оперативной памяти
        private List<Shape> _shapesList = new List<Shape>();
        private TextSerializer _serializer = new TextSerializer();
        private readonly string _filePath = "shapes_data.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        // Инициализация элементов управления данными
        private void InitializeCustomComponents()
        {
            comboBoxType.Items.Add("Point2D");
            comboBoxType.Items.Add("Circle");
            comboBoxType.Items.Add("Rectangle");
            comboBoxType.Items.Add("Square");
            comboBoxType.Items.Add("Triangle");
            comboBoxType.Items.Add("Ring");
            if (comboBoxType.Items.Count > 0) comboBoxType.SelectedIndex = 0;
        }

        // Обновление списка на форме
        private void RefreshListBox()
        {
            listBoxShapes.Items.Clear();
            foreach (var shape in _shapesList)
            {
                listBoxShapes.Items.Add($"{shape.ClassName} -> [{shape.GetInfo()}]");
            }
        }

        // Кнопка: Добавить новый объект в список
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string selectedType = comboBoxType.SelectedItem?.ToString();
            Shape newShape = null;

            if (selectedType == "Point2D") newShape = new Point2D(0, 0);
            else if (selectedType == "Circle") newShape = new Circle(5);
            else if (selectedType == "Rectangle") newShape = new Rectangle(8, 5);
            else if (selectedType == "Square") newShape = new Square(6);
            else if (selectedType == "Triangle") newShape = new Triangle();
            else if (selectedType == "Ring") newShape = new Ring();

            if (newShape != null)
            {
                _shapesList.Add(newShape);
                RefreshListBox();
                listBoxShapes.SelectedIndex = listBoxShapes.Items.Count - 1;
            }
        }

        // Кнопка: Удалить выбранный объект
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = listBoxShapes.SelectedIndex;
            if (index >= 0 && index < _shapesList.Count)
            {
                _shapesList.RemoveAt(index);
                RefreshListBox();
                textBoxProperties.Clear();
                pictureBoxRender.Invalidate(); // Очищаем холст, так как объект удален
            }
        }

        // Выбор элемента в ListBox
        private void listBoxShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxShapes.SelectedIndex;
            if (index >= 0 && index < _shapesList.Count)
            {
                textBoxProperties.Text = _shapesList[index].GetInfo();

                // КРИТИЧЕСКИ ВАЖНО: Заставляем PictureBox перерисоваться при смене выбора!
                pictureBoxRender.Invalidate();
            }
        }

        // Кнопка: Применить изменения свойств (Редактирование)
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int index = listBoxShapes.SelectedIndex;
            if (index >= 0 && index < _shapesList.Count)
            {
                try
                {
                    _shapesList[index].UpdateFromInfo(textBoxProperties.Text);
                    RefreshListBox();
                    listBoxShapes.SelectedIndex = index;

                    // Перерисовываем измененную фигуру на холсте
                    pictureBoxRender.Invalidate();

                    MessageBox.Show("Данные объекта успешно обновлены!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка формата ввода данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Кнопка: Сериализация списка в файл
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _serializer.Serialize(_filePath, _shapesList);
                MessageBox.Show("Список успешно сохранен в файл!", "Сериализация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка: Десериализация списка из файла
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                _shapesList = _serializer.Deserialize(_filePath);
                RefreshListBox();
                textBoxProperties.Clear();
                pictureBoxRender.Invalidate(); // Сбрасываем холст
                MessageBox.Show("Данные успешно загружены из файла!", "Десериализация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // НОВЫЙ МЕТОД: Событие отрисовки графики на PictureBox
        private void pictureBoxRender_Paint(object sender, PaintEventArgs e)
        {
            int index = listBoxShapes.SelectedIndex;
            // Если в списке выбрана фигура — рисуем её
            if (index >= 0 && index < _shapesList.Count)
            {
                // Находим центр холста PictureBox
                int centerX = pictureBoxRender.Width / 2;
                int centerY = pictureBoxRender.Height / 2;

                // Создаем синее перо толщиной 2 пикселя для контура
                using (Pen pen = new Pen(Color.Blue, 2))
                {
                    // Включаем сглаживание, чтобы линии не были "квадратными"
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    // ПОЛИМОРФНЫЙ ВЫЗОВ: фигура сама рисует себя в центре холста
                    _shapesList[index].Draw(e.Graphics, pen, centerX, centerY);
                }
            }
        }
    }
}