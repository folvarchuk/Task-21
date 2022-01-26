using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Задание_21
{
    /*Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. 
     *Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом. 
     *Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз. 
     *Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево. 
     *Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно. 
     *Создать многопоточное приложение, моделирующее работу садовников.*/
    class Program
    {
        const int n = 5;
        const int m = 4;
        static int[,] field = new int[n, m];
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Man1);
            Thread thread = new Thread(threadStart);
            thread.Start();
            Man2();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void Man1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (field[i, j] == 0)
                    {
                        field[i, j] = 1;
                    }
                    Thread.Sleep(1);
                }
            }    
        }

        static void Man2()
        {
            for (int i = m-1; i > 0; i--)
            {
                for (int j = n-1; j > 0; j--)
                {
                    if (field[j,i] != 1)
                    {
                        field[j, i] = 2;
                    }
                    Thread.Sleep(1);
                }
            }    
        }
    }
}
