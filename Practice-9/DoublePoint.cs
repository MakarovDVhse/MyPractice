using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_9
{
    public class DoublePoint
    {
        public int data; 
        public DoublePoint next, pred;
        public DoublePoint()
        {
            data = 0;
            next = null;
            pred = null;
        }
        public DoublePoint(int d)
        {
            data = d;
            next = null;
            pred = null;
        }
        public override string ToString()
        {
            return data + " ";
        }
        public static DoublePoint GenerateList(int size)
        {
            DoublePoint beg;
            Random random = new Random();
            if (size == 0)
                beg = null;
            else
            {
                beg = new DoublePoint(random.Next(-100000, 100000));
                for (int i = 0; i < size - 1; i++)
                {
                    DoublePoint point = new DoublePoint(random.Next(-100000, 100000));
                    point.next = beg;
                    beg.pred = point;
                    beg = point;
                }
            }
            return beg;
        }
        public static DoublePoint InputList(int size)
        {
            DoublePoint beg = new DoublePoint();
            Random random = new Random();
            if (size == 0)
                beg = null;
            else
            {
                bool ok;
                int helper;
                do
                {
                    ok = int.TryParse(Console.ReadLine(), out helper);
                    if (ok)
                        beg = new DoublePoint(helper);
                    else
                        Console.WriteLine("Введённый элемент не соответтсвует целому числу");
                } while (!ok);
                for (int i = 0; i < size - 1; i++)
                {
                    do
                    {
                        ok = int.TryParse(Console.ReadLine(), out helper);
                        if (ok)
                        {
                            DoublePoint point = new DoublePoint(helper);
                            point.next = beg;
                            beg.pred = point;
                            beg = point;
                        }
                        else
                            Console.WriteLine("Введённый элемент не соответтсвует целому числу");
                    } while (!ok);
                }
            }
            return beg;
        }
        public static void ShowList(DoublePoint beg)
        {
            DoublePoint point = beg;
            if (point == null)
                Console.WriteLine("Список пуст");
            else
            {
                while (point != null)
                {
                    if (point.next != null)
                        Console.Write(point.data + "; ");
                    else
                        Console.WriteLine(point.data);
                    point = point.next;
                }
            }
        }
        public static int FindDifference(DoublePoint beg)
        {
            int count = 0;
            DoublePoint point = beg;
            if (point == null)
                Console.WriteLine("Список пуст");
            else
            {
                while (point != null)
                {
                    if (point.data % 2 == 0)
                        count += point.data;
                    else
                        count -= point.data;
                    point = point.next;
                }
            }
            return Math.Abs(count);
        }
    }
}
