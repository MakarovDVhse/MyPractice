using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12
{
    public class Program
    {
        // данная задача находит практическую оценку методов сортировок: Сортировка простого выбора, Сортировка слиянием
        public static int Size;
        // массивы
        public static int[] AscendingMasSelection;
        public static int[] DescendingMasSelection;
        public static int[] NotOrderedMasSelecction;
        public static int[] AscendingMasM;
        public static int[] DescendingMasM;
        public static int[] NotOrderedMasM;
        // переменные подсчёта условий и пересылок
        public static int AscendingMasSelectionSortIfCount = 0;
        public static int AscendingMasSelectionsSortReArrangements = 0;
        public static int AscendingMasMergeSortIfCount = 0;
        public static int AscendingMasMergeSortReArrangements = 0;
        public static int DescendingMasSelectionSortIfCount = 0;
        public static int DescendingMasSelectionsSortReArrangements = 0;
        public static int DescendingMasMergeSortIfCount = 0;
        public static int DescendingMasMergeSortReArrangements = 0;
        public static int NotOrderedMasSelectionSortIfCount = 0;
        public static int NotOrderedMasSelectionsSortReArrangements = 0;
        public static int NotOrderedMasMergeSortIfCount = 0;
        public static int NotOrderedMasMergeSortReArrangements = 0;
        public static void InputSize()
        {
            bool ok;
            int n;
            do
            {
                Console.Write("Введите размерность массива n (целое число): ");
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok)
                    Console.WriteLine("Введённое значение не соответствует целому числу!");
                else if (n < 10)
                    Console.WriteLine("Размерность массива не может быть меньше 10, чтобы программа смогла корректно показать результаты сортировки.");
            } while (!ok || n < 10);
            Size = n;
        }
        public static void Ascending()
        {
            AscendingMasSelection = new int[Size];
            AscendingMasM = new int[Size];
            for (int i = 0; i < Size; i++)
            {
                AscendingMasSelection[i] = i + 1;
                AscendingMasM[i] = i + 1;
            }
        }
        public static void Descending()
        {
            DescendingMasSelection = new int[Size];
            DescendingMasM = new int[Size];
            for (int i = 0; i < Size; i++)
            {
                DescendingMasSelection[i] = Size - i;
                DescendingMasM[i] = Size - i;
            }
        }
        public static void NotOrdered()
        {
            NotOrderedMasSelecction = new int[Size];
            NotOrderedMasM = new int[Size];
            Random random = new Random();
            for (int i = 0; i < Size; i++)
            {
                NotOrderedMasSelecction[i] = random.Next(1, 1000000);
                NotOrderedMasM[i] = NotOrderedMasSelecction[i];
            }
        }
        public static void AscendingMasSelectionSort()
        {
            int PosofMin;
            int ReArrangeHelper;
            for (int i = 1; i < Size - 1; i++)
            {
                PosofMin = i - 1;
                for (int j = i; j < Size; j++)
                {
                    if (AscendingMasSelection[j] < AscendingMasSelection[i - 1])
                    {
                        PosofMin = j;
                    }
                    AscendingMasSelectionSortIfCount++;
                }
                if (PosofMin != i - 1)
                {
                    ReArrangeHelper = AscendingMasSelection[i - 1];
                    AscendingMasSelection[i - 1] = AscendingMasSelection[PosofMin];
                    AscendingMasSelection[PosofMin] = ReArrangeHelper;
                    AscendingMasSelectionsSortReArrangements++;
                }
            }
            Console.WriteLine("Количество сравнений для возрастающего массива: " + AscendingMasSelectionSortIfCount);
            Console.WriteLine("Количество пересылок для возрастающего массива: " + AscendingMasSelectionsSortReArrangements);
            Console.WriteLine(" ");
        }
        public static void DescendingMasSelectionSort()
        {
            int PosofMin;
            int ReArrangeHelper;
            for (int i = 1; i < Size - 1; i++)
            {
                PosofMin = i - 1;
                for (int j = i; j < Size; j++)
                {
                    if (DescendingMasSelection[j] < DescendingMasSelection[i - 1])
                    {
                        PosofMin = j;
                    }
                    DescendingMasSelectionSortIfCount++;
                }
                if (PosofMin != i - 1)
                {
                    ReArrangeHelper = DescendingMasSelection[i - 1];
                    DescendingMasSelection[i - 1] = DescendingMasSelection[PosofMin];
                    DescendingMasSelection[PosofMin] = ReArrangeHelper;
                    DescendingMasSelectionsSortReArrangements++;
                }
            }
            Console.WriteLine("Количество сравнений для убывающего массива: " + DescendingMasSelectionSortIfCount);
            Console.WriteLine("Количество пересылок для убывающего массива: " + DescendingMasSelectionsSortReArrangements);
            Console.WriteLine(" ");
        }
        public static void NotOrderedMasSelectionSort()
        {
            int PosofMin;
            int ReArrangeHelper;
            for (int i = 1; i < Size - 1; i++)
            {
                PosofMin = i - 1;
                for (int j = i; j < Size; j++)
                {
                    if (NotOrderedMasSelecction[j] < NotOrderedMasSelecction[i - 1])
                    {
                        PosofMin = j;
                    }
                    NotOrderedMasSelectionSortIfCount++;
                }
                if (PosofMin != i - 1)
                {
                    ReArrangeHelper = NotOrderedMasSelecction[i - 1];
                    NotOrderedMasSelecction[i - 1] = NotOrderedMasSelecction[PosofMin];
                    NotOrderedMasSelecction[PosofMin] = ReArrangeHelper;
                    NotOrderedMasSelectionsSortReArrangements++;
                }
            }
            Console.WriteLine("Количество сравнений для не упорядоченного массива: " + NotOrderedMasSelectionSortIfCount);
            Console.WriteLine("Количество пересылок для не упорядоченного массива: " + NotOrderedMasSelectionsSortReArrangements);
            Console.WriteLine(" ");
        }
        public static void AscendingMasMerge(int[] mas, int left, int middle, int right)
        {
            int HelperLeft = left;
            int HelperRight = middle + 1;
            int[] HelperMas = new int[right - left + 1];
            int index = 0;
            while ((HelperLeft <= middle) && (HelperRight <= right))
            {
                if (mas[HelperLeft] < mas[HelperRight])
                {
                    HelperMas[index] = mas[HelperLeft];
                    HelperLeft++;
                }
                else
                {
                    HelperMas[index] = mas[HelperRight];
                    HelperRight++;
                }
                index++;
                AscendingMasMergeSortIfCount++;
            }
            for (int i = HelperLeft; i <= middle; i++)
            {
                HelperMas[index] = mas[i];
                index++;
            }
            for (int i = HelperRight; i <= right; i++)
            {
                HelperMas[index] = mas[i];
                index++;
            }
            for (int i = 0; i < HelperMas.Length; i++)
            {
                mas[left + i] = HelperMas[i];
                AscendingMasMergeSortReArrangements++;
            }
        }
        public static int[] AscendingMasMergeSort(int[] mas, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                AscendingMasMergeSort(mas, left, middle);
                AscendingMasMergeSort(mas, middle + 1, right);
                AscendingMasMerge(mas, left, middle, right);
            }
            return mas;
        }
        public static void DescendingMasMerge(int[] mas, int left, int middle, int right)
        {
            int HelperLeft = left;
            int HelperRight = middle + 1;
            int[] HelperMas = new int[right - left + 1];
            int index = 0;
            while ((HelperLeft <= middle) && (HelperRight <= right))
            {
                if (mas[HelperLeft] < mas[HelperRight])
                {
                    HelperMas[index] = mas[HelperLeft];
                    HelperLeft++;
                }
                else
                {
                    HelperMas[index] = mas[HelperRight];
                    HelperRight++;
                }
                index++;
                DescendingMasMergeSortIfCount++;
            }
            for (int i = HelperLeft; i <= middle; i++)
            {
                HelperMas[index] = mas[i];
                index++;
            }
            for (int i = HelperRight; i <= right; i++)
            {
                HelperMas[index] = mas[i];
                index++;
            }
            for (int i = 0; i < HelperMas.Length; i++)
            {
                mas[left + i] = HelperMas[i];
                DescendingMasMergeSortReArrangements++;
            }
        }
        public static int[] DescendingMasMergeSort(int[] mas, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                DescendingMasMergeSort(mas, left, middle);
                DescendingMasMergeSort(mas, middle + 1, right);
                DescendingMasMerge(mas, left, middle, right);
            }
            return mas;
        }
        public static void NotOrdereddMasMerge(int[] mas, int left, int middle, int right)
        {
            int HelperLeft = left;
            int HelperRight = middle + 1;
            int[] HelperMas = new int[right - left + 1];
            int index = 0;
            while ((HelperLeft <= middle) && (HelperRight <= right))
            {
                if (mas[HelperLeft] < mas[HelperRight])
                {
                    HelperMas[index] = mas[HelperLeft];
                    HelperLeft++;
                }
                else
                {
                    HelperMas[index] = mas[HelperRight];
                    HelperRight++;
                }
                index++;
                NotOrderedMasMergeSortIfCount++;
            }
            for (int i = HelperLeft; i <= middle; i++)
            {
                HelperMas[index] = mas[i];
                index++;
            }
            for (int i = HelperRight; i <= right; i++)
            {
                HelperMas[index] = mas[i];
                index++;
            }
            for (int i = 0; i < HelperMas.Length; i++)
            {
                mas[left + i] = HelperMas[i];
                NotOrderedMasMergeSortReArrangements++;
            }
        }
        public static int[] NotOrderedMasMergeSort(int[] mas, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                NotOrderedMasMergeSort(mas, left, middle);
                NotOrderedMasMergeSort(mas, middle + 1, right);
                NotOrdereddMasMerge(mas, left, middle, right);
            }
            return mas;
        }
        public static void MergeSortOutput()
        {
            Console.WriteLine("Количество сравнений для возрастающего массива: " + AscendingMasMergeSortIfCount);
            Console.WriteLine("Количество пересылок для возрастающего массива: " + AscendingMasMergeSortReArrangements);
            Console.WriteLine(" ");
            Console.WriteLine("Количество сравнений для убывающего массива: " + DescendingMasMergeSortIfCount);
            Console.WriteLine("Количество пересылок для убывающего массива: " + DescendingMasMergeSortReArrangements);
            Console.WriteLine(" ");
            Console.WriteLine("Количество сравнений для не упорядоченного массива: " + NotOrderedMasMergeSortIfCount);
            Console.WriteLine("Количество пересылок для не упорядоченного массива: " + NotOrderedMasMergeSortReArrangements);
            Console.WriteLine(" ");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Чтобы программа смогла правильно проверить методы сортировок, вводите количество элементов в массивах от 10.");
            InputSize();
            Ascending();
            Descending();
            NotOrdered();
            Console.WriteLine("Сортировкаа простым выбором: ");
            Console.WriteLine(" ");
            AscendingMasSelectionSort();
            DescendingMasSelectionSort();
            NotOrderedMasSelectionSort();
            AscendingMasMergeSort(AscendingMasM, 0, Size - 1);
            DescendingMasMergeSort(DescendingMasM, 0, Size - 1);
            NotOrderedMasMergeSort(NotOrderedMasM, 0, Size - 1);
            Console.WriteLine("Сортировка слиянием: ");
            Console.WriteLine(" ");
            MergeSortOutput();
        }
    }
}
