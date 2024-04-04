using System;

class Program
{
    static void Main()
    {
        int m, n;

        // Введення розмірності першої матриці
        Console.Write("Введіть кількість рядків першої матриці (m): ");
        if (int.TryParse(Console.ReadLine(), out m))
        {
            Console.Write("Введіть кількість стовпців першої матриці (n): ");
            if (int.TryParse(Console.ReadLine(), out n))
            {
                // Введення елементів першої матриці
                int[,] matrixA = InputMatrix(m, n, "першої");

                // Введення розмірності другої матриці
                Console.Write("Введіть кількість рядків другої матриці (m): ");
                if (int.TryParse(Console.ReadLine(), out m))
                {
                    Console.Write("Введіть кількість стовпців другої матриці (n): ");
                    if (int.TryParse(Console.ReadLine(), out n))
                    {
                        // Введення елементів другої матриці
                        int[,] matrixB = InputMatrix(m, n, "другої");

                        // Виведення введених матриць
                        Console.WriteLine("Перша матриця (matrixA):");
                        PrintMatrix(matrixA);

                        Console.WriteLine("Друга матриця (matrixB):");
                        PrintMatrix(matrixB);

                        // Обчислення та виведення результатів
                        Console.WriteLine("Сума матриць:");
                        int[,] sum = MatrixSum(matrixA, matrixB);
                        PrintMatrix(sum);

                        Console.WriteLine("Різниця матриць:");
                        int[,] diff = MatrixDifference(matrixA, matrixB);
                        PrintMatrix(diff);

                        Console.WriteLine("Добуток матриць:");
                        int[,] product = MatrixProduct(matrixA, matrixB);
                        PrintMatrix(product);

                        Console.WriteLine("Середнє геометричне значення матриці А:");
                        double geoMeanA = GeometricMean(matrixA);
                        Console.WriteLine(geoMeanA);

                        Console.WriteLine("Середнє геометричне значення матриці B:");
                        double geoMeanB = GeometricMean(matrixB);
                        Console.WriteLine(geoMeanB);
                    }
                    else
                    {
                        Console.WriteLine("Помилка: Введено некоректну кількість стовпців другої матриці.");
                    }
                }
                else
                {
                    Console.WriteLine("Помилка: Введено некоректну кількість рядків другої матриці.");
                }
            }
            else
            {
                Console.WriteLine("Помилка: Введено некоректну кількість стовпців першої матриці.");
            }
        }
        else
        {
            Console.WriteLine("Помилка: Введено некоректну кількість рядків першої матриці.");
        }
    }

    // Метод для введення елементів матриці
    static int[,] InputMatrix(int m, int n, string name)
    {
        int[,] matrix = new int[m, n];
        Console.WriteLine($"Введення елементів {name} матриці:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"[{i}, {j}]: ");
                if (int.TryParse(Console.ReadLine(), out matrix[i, j]) == false)
                {
                    Console.WriteLine("Помилка: Введено некоректне значення для елементу матриці.");
                    i--; // Повторити введення для цього елементу
                }
            }
        }
        return matrix;
    }

    // Метод для обчислення суми матриць
    static int[,] MatrixSum(int[,] matrixA, int[,] matrixB)
    {
        int m = matrixA.GetLength(0);
        int n = matrixA.GetLength(1);
        int[,] result = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                result[i, j] = matrixA[i, j] + matrixB[i, j];
            }
        }
        return result;
    }

    // Метод для обчислення різниці матриць
    static int[,] MatrixDifference(int[,] matrixA, int[,] matrixB)
    {
        int m = matrixA.GetLength(0);
        int n = matrixA.GetLength(1);
        int[,] result = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                result[i, j] = matrixA[i, j] - matrixB[i, j];
            }
        }
        return result;
    }

    // Метод для обчислення добутку матриць
    static int[,] MatrixProduct(int[,] matrixA, int[,] matrixB)
    {
        int m = matrixA.GetLength(0);
        int n = matrixA.GetLength(1);
        int p = matrixB.GetLength(1);
        int[,] result = new int[m, p];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < p; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < n; k++)
                {
                    result[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }
        return result;
    }

    // Метод для обчислення середнього геометричного значення матриці
    static double GeometricMean(int[,] matrix)
    {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);
        double product = 1.0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                product *= matrix[i, j];
            }
        }
        return Math.Pow(product, 1.0 / (m * n));
    }

    // Метод для виведення матриці
    static void PrintMatrix(int[,] matrix)
    {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
