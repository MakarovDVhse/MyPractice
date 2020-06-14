using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    class Program
    {
        class Cell
        {
            public int value;
            public int PathCost;
            public char way;
            public Cell(int v)
            {
                value = v;
            }
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<Cell> HelpTable = new List<Cell>();
            List<List<Cell>> Table = new List<List<Cell>>();
            string helper;
            for (int i = 0; i < n; i++)
            {
                helper = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    Cell cell = new Cell(Convert.ToInt32(helper[j]));
                    HelpTable.Add(cell);
                }
                Table.Add(HelpTable);
                HelpTable = new List<Cell>();
            }
            Table[0][0].PathCost = Table[0][0].value;
            for (int i = 1; i < n; i++)
            {
                Table[i][0].PathCost = Table[i][0].value + Table[i - 1][0].PathCost;
                Table[i][0].way = 'u';
            }
            for (int i = 1; i < n; i++)
            {
                Table[0][i].PathCost = Table[0][i].value + Table[0][i - 1].PathCost;
                Table[0][i].way = 'l';
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    Table[i][j].PathCost = Math.Min(Table[i - 1][j].PathCost, Table[i][j - 1].PathCost) + Table[i][j].value;
                    if (Table[i - 1][j].PathCost < Table[i][j - 1].PathCost)
                        Table[i][j].way = 'u';
                    else
                        Table[i][j].way = 'l';
                }
            }
            char[,] Way = new char[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    Way[i, j] = '.';
            int indexi = n - 1;
            int indexj = n - 1;
            while (!(indexi == 0 && indexj == 0))
            {
                Way[indexi, indexj] = '#';
                if (Table[indexi][indexj].way == 'u')
                    indexi--;
                else
                    indexj--;
            }
            Way[indexi, indexj] = '#';
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (j != n - 1)
                        Console.Write(Way[i, j]);
                    else
                        Console.WriteLine(Way[i, j]);
                }
        }
    }
}
