using System.Drawing;

// Интерфейс фигуры (МОДЕЛЬ)
// Не содержит логики рисования!
public interface IShape
{
    // Метод возвращает границы фигуры
    Rectangle GetBounds();
}