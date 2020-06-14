using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_5
{
    // задача находит строку с одинаковыми элементами в двумерном массиве
    public class Program
    {
        public static int InputN()
        {
            bool ok;
            int n;
            do
            {
                Console.Write("Введите размерность двумерного массива n x n (целое число): ");
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok)
                    Console.WriteLine("Введённое значение не соответствует целому числу!");
                else if (n <= 0)
                    Console.WriteLine("Размерность массива не может быть меньше или равна нулю, иначе задача не имеет смысла.");
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
        public static int[,] GenerateMatrix(int n)
        {
            Random random = new Random();
            int[,] Matrix = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    Matrix[i, j] = Convert.ToInt32(random.Next(-10, 10));
            return Matrix;
        }
        public static int[,] InputMatrix(int n)
        {
            Console.WriteLine("Вводите массив построчно");
            Console.WriteLine("Массив состоит из целых чисел");
            string helper;
            int[,] Matrix = new int[n, n];
            bool ok, check;
            for (int i = 0; i < n; i++)
            {
                do
                {
                    helper = Console.ReadLine();
                    string[] numbers = helper.Split(' ');
                    ok = numbers.Length == n;
                    check = true;
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (!int.TryParse(numbers[j], out Matrix[i, j]))
                            check = false;
                    }
                    if (!ok)
                        Console.WriteLine("Входная строка не содержит необхдимых {n} элементов", n);
                    else if (!check)
                        Console.WriteLine("Какое-то из вводимых значений в строке не является целым числом");
                } while (!ok || !check);
            }
            return Matrix;
        }
        public static List<int> FindStrings(int[,] Matrix, int n)
        {
            List<int> Indexes = new List<int>();
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                count = 1;
                for (int j = 1; j < n; j++)
                {
                    if (Matrix[i, j] == Matrix[i, 0])
                        count++;
                }
                if (count == n)
                    Indexes.Add(i + 1);
            }
            return Indexes;
        }
        static void Main(string[] args)
        {
            int n = InputN();
            int[,] Matrix = new int[n, n];
            int option = InputOption();
            switch (option)
            {
                case 1:
                    Matrix = InputMatrix(n);
                    break;
                case 2:
                    Matrix = GenerateMatrix(n);
                    break;
            }
            List<int> Indexes = FindStrings(Matrix, n);
            if (Indexes.Count == 0)
                Console.WriteLine("Строк с одинаковыми элементами нет");
            else
            {
                Console.Write("Номера строк, содержащие одинаковые элементы: ");
                foreach (int elem in Indexes)
                    Console.Write(elem + " ");
            }
        }
    }
}
