using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practice_10
{
    // данная программа умножает два полинома друг на друга
    public class Program
    {
        public static bool FileExistance(string path)
        {
            return File.Exists(path);
        }
        public static bool FileNothingcheck(string path1, string path2)
        {
            string[] data1 = File.ReadAllLines(path1);
            string[] data2 = File.ReadAllLines(path2);
            return data1.Length != 0 && data2.Length != 0;
        }
        public static bool FileCheckRightInput(string path1, string path2)
        {
            string[] data1 = File.ReadAllLines(path1);
            string[] data2 = File.ReadAllLines(path2);
            bool check = true;
            for (int i = 0; i < data1.Length; i++)
            {
                string[] helper = data1[i].Split(' ');
                if (helper.Length != 2)
                    check = false;
            }
            for (int i = 0; i < data2.Length; i++)
            {
                string[] helper = data2[i].Split(' ');
                if (helper.Length != 2)
                    check = false;
            }
            return check;
        }
        public static bool FileCheckElements(string path1, string path2)
        {
            string[] data1 = File.ReadAllLines(path1);
            string[] data2 = File.ReadAllLines(path2);
            bool check = true;
            int help1;
            double help2;
            for (int i = 0; i < data1.Length; i++)
            {
                string[] helper = data1[i].Split(' ');
                if (!(int.TryParse(helper[0], out help1) && double.TryParse(helper[1], out help2)))
                {
                    check = false;
                }
            }
            for (int i = 0; i < data2.Length; i++)
            {
                string[] helper = data2[i].Split(' ');
                if (!(int.TryParse(helper[0], out help1) && double.TryParse(helper[1], out help2)))
                {
                    check = false;
                }
            }
            return check;
        }
        public static bool PolinomNothingCheck(Polinom FirstPolinom, Polinom SecondPolinom)
        {
            return FirstPolinom.Count != 0 && SecondPolinom.Count != 0;
        }
        public static Polinom PolinomInput(Polinom polinom1, string path)
        {
            string[] data1 = File.ReadAllLines(path);
            int help1;
            double help2;
            for (int i = 0; i < data1.Length; i++)
            {
                string[] helper = data1[i].Split(' ');
                if (int.TryParse(helper[0], out help1) && double.TryParse(helper[1], out help2))
                {
                    Element element = new Element(help1, help2);
                    polinom1.Add(element);
                }
            }
            return polinom1;
        }
        public static Polinom Multiplication(Polinom FirstPolinom, Polinom SecondPolinom, Polinom ThirdPolinom)
        {
            for (int i = 0; i < FirstPolinom.Count; i++)
            {
                for (int j = 0; j < SecondPolinom.Count; j++)
                {
                    Element element = new Element(FirstPolinom.polinom[i].exponent + SecondPolinom.polinom[j].exponent, FirstPolinom.polinom[i].coefficient * SecondPolinom.polinom[j].coefficient);
                    ThirdPolinom.Add(element);
                }
            }
            return ThirdPolinom;
        } 
        public static void Output(StreamWriter output, Polinom ThirdPolinom)
        {
            for (int i = 0; i < ThirdPolinom.Count; i++)
            {
                output.WriteLine(ThirdPolinom.polinom[i].exponent + " " + ThirdPolinom.polinom[i].coefficient);
            }
        }
        public static void Main(string[] args)
        {
            string path1 = @"C:\PracticeFiles\Input1.txt";
            string path2 = @"C:\PracticeFiles\Input2.txt"; 
            if (FileExistance(path1) && FileExistance(path2))
            {
                if (FileNothingcheck(path1, path2))
                {
                    if (FileCheckRightInput(path1, path2))
                    {
                        if (FileCheckElements(path1, path2))
                        {
                            Polinom FirstPolinom = new Polinom();
                            Polinom SecondPolinom = new Polinom();
                            FirstPolinom = PolinomInput(FirstPolinom, path1);
                            SecondPolinom = PolinomInput(SecondPolinom, path2);
                            if (PolinomNothingCheck(FirstPolinom, SecondPolinom))
                            {
                                Polinom ThirdPolinom = new Polinom();
                                ThirdPolinom = Multiplication(FirstPolinom, SecondPolinom, ThirdPolinom);
                                StreamWriter output = new StreamWriter(@"C:\PracticeFiles\output.txt");
                                ThirdPolinom.Sorting();
                                Output(output, ThirdPolinom);
                                output.Close();
                                Console.WriteLine("Программа завершила работу");
                                Console.WriteLine("Проверьте файлы в деректории");
                            }
                            else
                            {
                                Console.WriteLine("Умножение не имеет смысла, так как один из полиномов равен нулю");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Какой-то из элементов в файле не соответствует необходимому типу данных.");
                            Console.WriteLine("Проверте входные данные в файлах");
                        }
                    }
                    else
                    {
                        Console.WriteLine("В каком-то из файлов не правильно записаны вхоные данные.");
                        Console.WriteLine("Возможно в какой-то из строк в файлах больше или меньше 2 элементов.");
                        Console.WriteLine("Проверьте файлы");
                    }
                }
                else
                {
                    Console.WriteLine("возможжно какой-то из файлов пустой");
                    Console.WriteLine("Проверьте содержимое файлов");
                }
            }
            else
            {
                Console.WriteLine("Возможно кокого-то из файов не существует.");
                Console.WriteLine("Проверьте существование файлов");
            }
        }
    }
}
