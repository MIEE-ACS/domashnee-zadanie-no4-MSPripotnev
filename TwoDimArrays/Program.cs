using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DoubleDimensionalArrays
{
    class Program
    {
        static int[,] Compress(int[,] A)
        {
            List<int> ZeroRowsIndexes = new List<int>();
            List<int> ZeroColumnIndexes = new List<int>();
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int j;
                for (j = 0; j < A.GetLength(1) && A[i, j] == 0; j++) ;
                if (j == A.GetLength(1))
                    ZeroRowsIndexes.Add(i);
            }
            for (int i = 0; i < A.GetLength(0); i++)
            {
                int j;
                for (j = 0; j < A.GetLength(1) && A[j, i] == 0; j++) ;
                if (j == A.GetLength(1))
                    ZeroColumnIndexes.Add(i);
            }

            int[,] result = new int[A.GetLength(0) - ZeroRowsIndexes.Count, A.GetLength(1) - ZeroColumnIndexes.Count];
            for (int i = 0, i2 = 0; i < A.GetLength(0); i++, i2++)
            {
                while (ZeroRowsIndexes.Contains(i)) i++;
                if (i == A.GetLength(0)) break;
                for (int j = 0, j2 = 0; j < A.GetLength(1); j++, j2++)
                {
                    while (ZeroColumnIndexes.Contains(j)) j++;
                    if (j == A.GetLength(1)) break;
                    result[i2, j2] = A[i, j];
                }
            }
            return result;
        }
        static void MatrixPrint<T>(T[,] matrix, string name)
        {
            Console.WriteLine($"Матрица {name}:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j]} ");
                Console.WriteLine();
            }
        }
        static void PrintFirstPositiveRowIndex(int[,] D)
        {
            try
            {
                Console.WriteLine($"Индекс первой строки с хотя бы одним положительным элементом: " +
                    $"{Array.FindIndex<int>(D.Cast<int>().ToArray(), (el) => (el > 0)) / D.GetLength(1)}");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Ни одного положительного элемента не найдено.");
            }
            Console.WriteLine();
        }
             
        static void Main(string[] args)
        {
            int[,] A =
            {
                {0, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1 },
                {0, 1, 1, 0, 1 },
                {0, 0, 0, 0, 0 },
                {0, 1, 1, 0, 0 }
            };
            int[,] B =
            {
                {0, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1 },
                {1, 1, 1, 1, 1 },
                {1, 0, 0, 0, 0 },
                {1, 1, 1, 0, 0 }
            };
            int[,] C =
            {
                {0, 3, 4, 0, 0 },
                {0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0 },
                {5, 6, 2, 0, 0 }
            };

            A = Compress(A);
            B = Compress(B);
            C = Compress(C);

            MatrixPrint<int>(A, nameof(A));
            PrintFirstPositiveRowIndex(A);
            MatrixPrint<int>(B, nameof(B));
            MatrixPrint<int>(C, nameof(C));

            Console.WriteLine();
            int[,] D =
            {
                {-4, -3, -4, 0, 0 },
                {0, -5, 0, 0, 0 },
                {0, 3, 0, 0, 0 },
                {0, 0, 0, 0, 0 },
                {5, 6, 2, 0, 0 }
            };

           
            MatrixPrint(D, nameof(D));
            PrintFirstPositiveRowIndex(D);

            D = Compress(D);
            MatrixPrint(D, nameof(D)+" (сжатая)");
            PrintFirstPositiveRowIndex(D);

            int[,] F =
            {
                {-1, -1, -1, 0, 0 },
                {0, -1, 0, 0, 0 },
                {0, -1, 0, 0, 0 },
                {0, 0, 0, 0, 1 },
                {5, 6, 2, -3, 0 }
            };
            MatrixPrint(F, nameof(F));
            PrintFirstPositiveRowIndex(F);
        }
    }
}
