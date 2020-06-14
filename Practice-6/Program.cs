using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_6
{
    public class Program
    {
        // данная задача находит полседующие члены последовательности от трёх предыдущих 
        // (если надо найти N элементов, то будут найдены ещё N - 3 элементов
        public static int N;
        public static List<double> InputSequence(List<double> sequence)
        {
            string helper;
            bool Right = true;
            bool ok = true; 
            bool check = true;
            bool checkLength = true;
            do
            {
                ok = true;
                check = true;
                checkLength = true;
                helper = Console.ReadLine();
                string[] numbers = helper.Split(' ');
                double elem;
                if (numbers.Length != 4)
                    checkLength = false;
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (!double.TryParse(numbers[i], out elem))
                        check = false;
                    else
                        sequence.Add(elem);
                }
                if (!int.TryParse(numbers[numbers.Length - 1], out N))
                    ok = false;
                else if (N < 3)
                    Right = false;
                if (!ok)
                {
                    Console.WriteLine("Последний элемент введённой строки не является целым числом");
                    sequence.Clear();
                }
                else if (!Right)
                {
                    Console.WriteLine("Количество новых элементов в последовательности не может быть меньше нуля");
                    sequence.Clear();
                }
                else if (!check)
                {
                    Console.WriteLine("Один из элементов в последовательности не является действительным числом");
                    sequence.Clear();
                }
                else if (!check)
                {
                    Console.WriteLine("В вводимой строке либо не достаточно элементов, либо их количество элементов преувеличено");
                    sequence.Clear();
                }
            } while (!ok || !check || !checkLength || !Right);
            return sequence;
        }
        public static void OutputSequence(List<double> sequence)
        {
            Console.Write("Полученная последовательность: ");
            for (int i = 0; i < N; i++)
            {
                if (i != N - 1)
                    Console.Write(sequence[i] + "; ");
                else
                    Console.WriteLine(sequence[i] + " ");
            }
        }
        public static void CheckTheSequence(List<double> sequence)
        {
            bool Increasing = true;
            bool Nondecreasing = true;
            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i] < sequence[i - 1])
                {
                    Increasing = false;
                    Nondecreasing = false;
                }
                else if (sequence[i] == sequence[i - 1])
                    Increasing = false;
            }
            if (Increasing && Nondecreasing)
                Console.WriteLine("Данная последовательность строго возрастающая");
            else if (!Increasing && Nondecreasing)
                Console.WriteLine("Данная последовательность монотонно неубывающая");
            else
                Console.WriteLine("Данная последовательность не является ни монотонно неубывающей, ни строго возрастающей");
        }
        public static List<double> RecursiveSequence(List<double> sequence)
        {
            double NewElement = (sequence[sequence.Count - 1] + 1) / (sequence[sequence.Count - 2] + 2) * sequence[sequence.Count - 3];
            sequence.Add(NewElement);
            if (sequence.Count == N)
                return sequence;
            else
                return RecursiveSequence(sequence);
        }
        static void Main(string[] args)
        {
            List<double> sequence = new List<double>();
            Console.WriteLine("Введите данные (a1, a2, a3, N) через пробел,");
            Console.WriteLine("где a1 - a3 - первые члены последовательности, а N - общее число элементов в последовательности.");
            sequence = InputSequence(sequence);
            sequence = RecursiveSequence(sequence);
            OutputSequence(sequence);
            CheckTheSequence(sequence);
        }
    }
}
