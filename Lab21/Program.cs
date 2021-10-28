using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab21
{
    class Program
    {
        private static int[,] field;
        static void Main(string[] args)
        {
            field = new int[10, 8];
            Thread gardener1 = new Thread(Gardener1);
            Thread gardener2 = new Thread(Gardener2);
            gardener1.Start();
            gardener2.Start();

            gardener1.Join();
            gardener2.Join();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0}  ", field[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        private static void Gardener1()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (field[i, j] == 0)
                    {
                        field[i, j] = 1;
                    }
                    Thread.Sleep(1);
                }
            }
        }
        private static void Gardener2()
        {
            for (int i = 7; i > 0; i--)
            {
                for (int j = 9; j > 0; j--)
                {
                    if (field[j, i] == 0)
                    {
                        field[j, i] = 2;
                    }
                    Thread.Sleep(1);
                }
            }
        }
    }
}
