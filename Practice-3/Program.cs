using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_3
{
    public class Program
    {
        // задача находит, принадлежит ли точка указанной  задаче области
        public static double XInput()
        {
            bool ok;
            double x;
            do
            {
                Console.Write("Введите действительное число x (координата по оси абцисс): ");
                ok = double.TryParse(Console.ReadLine(), out x);
                if (!ok)
                    Console.WriteLine("Введённое значение не соответствует действительному числу!");
            } while (!ok);
            return x;
        }
        public static double YInput()
        {
            bool ok;
            double y;
            do
            {
                Console.Write("Введите действительное число y (координата по оси ординат): ");
                ok = double.TryParse(Console.ReadLine(), out y);
                if (!ok)
                    Console.WriteLine("Введённое значение не соответствует действительному числу!");
            } while (!ok);
            return y;
        }
        public static bool Predicate(double x, double y)
        {
            bool ok;
            ok = (y <= -x && y <= x + 3 && y >= (x - 3)/3 && x <= 0) || (y <= 0 && y >= (x-3)/3 && x >= 0);
            return ok;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Сначала введите значение x, а потом значение y");
            double x = XInput();
            double y = YInput();
            if (Predicate(x, y))
                Console.WriteLine("Точка ({0}; {1}) принадлежит заданной области", x, y);
            else
                Console.WriteLine("Точка ({0}; {1}) не принадлежит заданной области", x, y);
        }
    }
}
