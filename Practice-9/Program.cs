using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_9
{
    public class Program
    {
        // данная задача находит разность между суммой чётных элементов и нечётных
        public static int InputN()
        {
            bool ok;
            int n;
            do
            {
                Console.Write("Введите размерность двунаправленного списка: ");
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok)
                    Console.WriteLine("Введённое значение не соответствует целому числу!");
                else if (n <= 0)
                    Console.WriteLine("Размерность списка не может быть меньше или равна нулю, иначе задача не имеет смысла.");
            } while (!ok || n <= 0);
            return n;
        }
        public static int InputOption()
        {
            bool ok;
            int n;
            Console.WriteLine("Выберете опцию: ");
            Console.WriteLine("1. Ввод массива вручную");
            Console.WriteLine("2. Генерация массива датчиком случайных чисел");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok)
                    Console.WriteLine("Такой опции нет");
                else if (n <= 0 || n >= 3)
                    Console.WriteLine("Такой опции нет");
            } while (!ok || n <= 0 || n >= 3);
            return n;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Вы можете либо сгенерировать входные данные, либо ввести их вручную.");
            int n = InputN();
            DoublePoint list = new DoublePoint();
            switch (InputOption())
            {
                case 1:
                    list = DoublePoint.InputList(n);
                    break;
                case 2:
                    list = DoublePoint.GenerateList(n);
                    break;
            }
            int count = DoublePoint.FindDifference(list);
            Console.Write("Список: ");
            DoublePoint.ShowList(list);
            Console.WriteLine("Разность сумм чётных и нечётных элементов по модулю равна = {0}", count);
        }
    }
}
