using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_7
{
    public class Program
    {
        // данная программа строит кодовые слова Грэя с указанной длиной
        public static int InputN()
        {
            bool ok;
            int n;
            do
            {
                Console.Write("Введите длину кодовых слов Грэя: ");
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok)
                    Console.WriteLine("Введённое значение не соответствует целому числу!");
                else if (n <= 0)
                    Console.WriteLine("Размерность слова не может быть меньше или равна нулю, иначе задача не имеет смысла.");
            } while (!ok || n <= 0);
            return n;
        }
        public static int[,] BuildGrayCode(int n, int[,] GrayCode)
        {
            GrayCode[0, n - 1] = 0;
            GrayCode[1, n - 1] = 1;
            int count = 2;
            for (int i = 1; i < n; i++)
            {
                int temp = count - 1;
                count *= 2;
                for (int j = count/2; j < count; j++)
                {
                    for (int h = 0; h < n; h++)
                        GrayCode[j, h] = GrayCode[temp, h];
                    GrayCode[temp, n - i - 1] = 0;
                    GrayCode[j, n - i - 1] = 1;
                    temp--;
                }
            }
            return GrayCode;
        }
        static void Main(string[] args)
        {
            int n = InputN();
            int[,] GrayCode = new int[Convert.ToInt32(Math.Pow(2, n)), n];
            GrayCode = BuildGrayCode(n, GrayCode);
            for (int i = 0; i < Convert.ToInt32(Math.Pow(2, n)); i++)
            {
                Console.Write(i + ": ");
                for (int j = 0; j < n; j++)
                {
                    if (j != n - 1)
                        Console.Write(GrayCode[i, j]);
                    else
                        Console.WriteLine(GrayCode[i, j]);
                }
            }
        }
    }
}
