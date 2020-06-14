using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_8
{
    public class Program
    {
        // данная задача находит клику из введённого количества вершин в сгенерированном графе
        public static int InputClique()
        {
            bool ok;
            int n;
            do
            {
                Console.Write("Введите количество вершин, из которых будет состоять клика: ");
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok)
                    Console.WriteLine("Введённое значение не соответствует целому числу!");
                else if (n <= 0)
                    Console.WriteLine("Размерность клики не может быть меньше или равен нулю");
            } while (!ok || n <= 0);
            return n;
        }
        public static bool CliqueCheck(int[,] Matrix, int clique)
        {
            if (Matrix.GetLength(1) < clique * (clique - 1) / 2)
                return false;
            else
                return true;
        }
        public static int[,] TestGenerator()
        {
            Random random = new Random();
            int vertices = random.Next(2, 10);
            int ways = random.Next(1, (vertices * (vertices - 1)) / 2);
            int[,] Matrix = new int[vertices, ways];
            for (int i = 0; i < ways; i++)
            {
                int vertex1, vertex2;
                vertex1 = random.Next(0, vertices);
                vertex2 = random.Next(0, vertices);
                if (vertex1 == vertex2)
                    i--;
                else
                {
                    bool check = true;
                    for (int j = 0; j < i; j++)
                    {
                        if (Matrix[vertex1, j] == 1 && Matrix[vertex2, j] == 1)
                            check = false;
                    }
                    if (check)
                    {
                        Matrix[vertex1, i] = 1;
                        Matrix[vertex2, i] = 1;
                    }
                    else
                        i--;
                }
            }
            return Matrix;
        }
        public static void MatrixOutput(int[,] Matrix)
        {
            Console.WriteLine("Матрица инциденций: ");
            Console.WriteLine(" ");
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                Console.Write((i + 1) + ": ");
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (j != Matrix.GetLength(1) - 1)
                        Console.Write(Matrix[i, j] + " ");
                    else
                        Console.WriteLine(Matrix[i, j]);
                }
            }
        }
        public static int[,] MakeVerticesMatrix(int[,] Matrix)
        {
            int[,] VerticesMatrix = new int[Matrix.GetLength(0), Matrix.GetLength(0)];
            int vertex1, vertex2;
            for (int i = 0; i < Matrix.GetLength(1); i++)
            {
                vertex1 = -1;
                vertex2 = -1;
                for (int j = 0; j < Matrix.GetLength(0); j++)
                {
                    if (Matrix[j, i] == 1 && vertex1 == -1)
                        vertex1 = j;
                    else if (Matrix[j, i] == 1 && vertex1 != -1)
                        vertex2 = j;
                }
                VerticesMatrix[vertex1, vertex2] = 1;
                VerticesMatrix[vertex2, vertex1] = 1;
            }
            return VerticesMatrix;
        }
        public static void CliqueFind(int clique, int[,] VerticesMatrix)
        {
            List<int> PossibleCliqueVertices = new List<int>();
            int count;
            for (int i = 0; i < VerticesMatrix.GetLength(0); i++)
            {
                count = 0;
                for (int j = 0; j < VerticesMatrix.GetLength(1); j++)
                {
                    if (VerticesMatrix[i, j] == 1)
                        count++;
                }
                if (count + 1 >= clique)
                    PossibleCliqueVertices.Add(i + 1);
            }
            if (PossibleCliqueVertices.Count < clique)
                Console.WriteLine("Клики из {0} вершин в графе нет", clique);
            else
            {
                bool check = false;
                List<int> CliqueVertices = new List<int>();
                for (int i = 0; i < PossibleCliqueVertices.Count - clique + 1; i++)
                {
                    CliqueVertices.Add(PossibleCliqueVertices[i]);
                    for (int j = i; j < PossibleCliqueVertices.Count; j++)
                    {
                        bool CheckVertices = true;
                        for (int k = 0; k < CliqueVertices.Count; k++)
                        {
                            if (!(VerticesMatrix[PossibleCliqueVertices[j] - 1, CliqueVertices[k] - 1] == 1))
                                CheckVertices = false;
                        }
                        if (CheckVertices)
                            CliqueVertices.Add(PossibleCliqueVertices[j]);
                        if (CliqueVertices.Count == clique)
                        {
                            check = true;
                            j = PossibleCliqueVertices.Count;
                        }
                    }
                    if (check)
                        i = PossibleCliqueVertices.Count;
                }
                if (check)
                    CliqueOutput(CliqueVertices);
                else
                    Console.WriteLine("Клики с таким количеством вершин в данном графе нет");
            }
        }
        public static void CliqueOutput(List<int> CliqueVertices)
        {
            Console.Write("Клика состоит из вершин: ");
            for (int i = 0; i < CliqueVertices.Count; i++)
            {
                if (i != CliqueVertices.Count - 1)
                    Console.Write(CliqueVertices[i] + " ");
                else
                    Console.WriteLine(CliqueVertices[i]);
            }
            Console.WriteLine(" ");
        }
        static void Main(string[] args)
        {
            int[,] Matrix = TestGenerator();
            MatrixOutput(Matrix);
            int[,] VerticesMatrix = MakeVerticesMatrix(Matrix);
            int clique = InputClique();
            if (CliqueCheck(Matrix, clique))
            {
                CliqueFind(clique, VerticesMatrix);
            }
            else
            {
                Console.WriteLine("Такой клики в данном графе не существует.");
            }
        }
    }
}
