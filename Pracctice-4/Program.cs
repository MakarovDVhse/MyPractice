using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracctice_4
{
    public class Program
    {
        // данная задача находит x, где f(x) = 0 методом хорд (также дана область для нахождения значения
        public static double EpsInput()
        {
            bool ok;
            double eps;
            do
            {
                Console.Write("Введите действительное число eps (заданая точность для нахождения x при f(x)) = 0: ");
                ok = double.TryParse(Console.ReadLine(), out eps);
                if (!ok)
                    Console.WriteLine("Введённое значение не соответствует действительному числу!");
                else if (eps < 0)
                    Console.WriteLine("Точность не может быть отрицательной.");
                else if (eps >= 0.01)
                    Console.WriteLine("Точность не может быть настолько большой.");
            } while (!ok || eps < 0 || eps >= 0.01);
            return eps;
        }
        public static double Function(double x)
        {
            return 2 * Math.Pow(Math.Sin(2 * x), 2) / 3 - 3 * Math.Pow(Math.Cos(2 * x), 2) / 4;
        }
        public static double ChordMethod(double eps, double prev, double curr)
        {
            double x = 0;
            double temp;
            do
            {
                temp = x;
                x = curr - Function(curr) * (prev - curr) / (Function(prev) - Function(curr));
                prev = curr;
                curr = temp;
            } while (Math.Abs(x - curr) > eps);
            return x;
        }
        static void Main(string[] args)
        {
            double eps = EpsInput();
            Console.Write("Решение уравнения 2sin(2x)^2/3 - 3cos(2x)^2/4 = 0: ");
            Console.WriteLine(ChordMethod(eps, 0, Math.PI / 4));
        }
    }
}
