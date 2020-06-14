using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] Cordinates = new int[n, 3];
            string helper;
            for (int i = 0; i < n; i++)
            {
                helper = Console.ReadLine();
                string[] numbers = helper.Split(' ');
                for (int j = 0; j < 3; j++)
                    Cordinates[i, j] = Convert.ToInt32(numbers[j]);
            }
            double s;
            if (n == 1)
            {
                s = Math.Pow(Cordinates[0, 2], 2) / 2;
                Console.WriteLine("{0:0.000}", s);
            }
            else
            {
                int xtr = Cordinates[0, 0];
                int ytr = Cordinates[0, 1];
                int ktr = Cordinates[0, 2];
                int xi, yi, ki;
                int[] vector = new int[4];
                for (int i = 1; i < n; i++)
                {
                    xi = xtr;
                    yi = ytr;
                    ki = ktr;
                    if (Cordinates[i, 0] > xtr)
                        xtr = Cordinates[i, 0];
                    if (Cordinates[i, 1] > ytr)
                        ytr = Cordinates[i, 1];
                    if (xtr == xi && ytr == yi)
                    {
                        if (ki < Cordinates[i, 2] - ((xtr - Cordinates[i, 0]) + (ytr - Cordinates[i, 1])))
                            ktr = ki;
                        else if (Cordinates[i, 2] - ((xtr - Cordinates[i, 0]) + (ytr - Cordinates[i, 1])) <= 0)
                            ktr = 0;
                        else if (ki >= Cordinates[i, 2] - ((xtr - Cordinates[i, 0]) + (ytr - Cordinates[i, 1])))
                            ktr = Cordinates[i, 2] - ((xtr - Cordinates[i, 0]) + (ytr - Cordinates[i, 1]));
                    }
                    else if (Cordinates[i, 0] == xtr && Cordinates[i, 1] == ytr)
                    {
                        if (Cordinates[i, 2] < ki - ((xtr - xi) + (ytr - yi)))
                            ktr = Cordinates[i, 2];
                        else if (ki - ((xtr - xi) + (ytr - yi)) <= 0)
                            ktr = 0;
                        else if (Cordinates[i, 2] >= ki - ((xtr - xi) + (ytr - yi)))
                            ktr = ki - ((xtr - xi) + (ytr - yi));
                    }
                    else
                    {
                        vector[0] = xi + ki - xtr;
                        vector[1] = yi + ki - ytr;
                        vector[2] = Cordinates[i, 0] + Cordinates[i, 2] - xtr;
                        vector[3] = Cordinates[i, 1] + Cordinates[i, 2] - ytr;
                        Array.Sort(vector);
                        if (vector[0] <= 0)
                            ktr = 0;
                        else
                            ktr = vector[0];
                    }
                }
                s = Math.Pow(ktr, 2) / 2;
                Console.WriteLine("{0:0.000}", s);
            }
        }
    }
}
