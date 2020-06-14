using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_11
{
    // данная программа шифрует определённую последовательность по правилу
    // первый элемент равен себе же, а последующие элементы равны
    // либо 1, если следующий равен предыдущему
    // либо 0, если следующий не равен предыдущему
    public static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
