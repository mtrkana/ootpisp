using oop_2;
using System;
using System.Windows.Forms;

// Точка входа в программу
internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}