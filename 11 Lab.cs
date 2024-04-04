using System;
using System.Threading.Tasks;

class Program
{
    static double Ln(double x, int n)
    {
        double result = 0;

        for (int i = 1; i <= n; i++)
        {
            double term = Math.Pow((x - 1) / (x + 1), (2 * i - 1)) / (2 * i - 1);
            if (i % 2 == 0)
                result -= term;
            else
                result += term;
        }

        return 2 * result;
    }

    static double LnWithPrecision(double x, double precision)
    {
        double result = 0;
        double term = 1;
        int n = 1;

        while (Math.Abs(term) > precision)
        {
            term = Math.Pow((x - 1) / (x + 1), (2 * n - 1)) / (2 * n - 1);
            if (n % 2 == 0)
                result -= term;
            else
                result += term;
            n++;
        }

        return 2 * result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter x:");
        double x = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter number of iterations:");
        int iterations = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter precision:");
        double precision = double.Parse(Console.ReadLine());

        double oddResult = 0;
        double evenResult = 0;

        Parallel.Invoke(
            () => oddResult = Ln(x, iterations),
            () => evenResult = Ln(x, iterations)
        );

        double result = oddResult + evenResult;
        Console.WriteLine($"Using {iterations} iterations result: {result}");

        double resultWithPrecision = LnWithPrecision(x, precision);
        Console.WriteLine($"Result with precision {precision}: {resultWithPrecision}");
    }
}
