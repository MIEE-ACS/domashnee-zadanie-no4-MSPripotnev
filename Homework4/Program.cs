using Microsoft.VisualBasic;
using System;
using System.Linq;

namespace SingleDimensionalArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1;
            Console.Write("Введите размер массива: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                Console.WriteLine("Некорректный ввод размера массива! Пожалуйста, введите целое положительное число: ");
            double[] A = new double[n];

            double a=1, b=1;
            Console.WriteLine("Введите два числа из интервала [a;b]: ");
            while (!double.TryParse(Console.ReadLine(), out a) || !double.TryParse(Console.ReadLine(), out b) || b < a)
                Console.WriteLine("Некорректный ввод интервала! Пожалуйста, введите два числа так, что (a < b): ");

            Console.WriteLine("Массив A: ");
            for (int i = 0; i < A.Length; i++)
                A[i] = (new Random()).NextDouble() * 100 * Math.Pow(-1, (new Random()).Next());
            Array.ForEach(A, (el) => Console.Write($"{el:0.00}; "));
            Console.WriteLine();
            var imin = Array.FindIndex(A, p => Math.Abs(p) <= Math.Abs(A.Min()));
            Console.WriteLine($"Индекс минимального элемента в массиве: {imin}");

            try
            {
                double sum = 0;
                Array.ForEach(A.Where(p => Array.IndexOf(A, p) > Array.IndexOf(A, A.First(p => p < 0))).ToArray(),
                    (el) => sum += Math.Abs(el));
                Console.WriteLine($"Сумма по модулю элементов массива после первого отрицательного: {sum}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Не найдено отрицательных элементов в массиве.");
            }

            var vs = A.Where(p => p >= a && p <= b).ToArray();
            Array.ConstrainedCopy(vs, 0, A, 0, vs.Length);
            Array.Clear(A, vs.Length, A.Length-vs.Length);
            Array.ForEach(A, (el) => { el = 0; });
            Console.WriteLine("Массив A (после сжатия): ");
            Array.ForEach(A, (el) => Console.Write($"{el:0.00}; "));
            Console.WriteLine();
        }
    }
}