
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = 8;

        for (int i = 0; i < n; i++)
        {
            for (int j = n - i; j >= 1; j--)
            {
                Console.Write(" ");
            }

            for (int j = 0; j <= i; j++)
            {
                Console.Write("#");
            }
            //Console.WriteLine("#");

            Console.Write("   ");

            for (int j = 0; j <= i; j++)
            {
                Console.Write("#");
            }
            Console.WriteLine(" ");

        }

        try
        {
            int a = 10;
            int b = 0;
            //int d = int.Parse("x");
            //int c = a / b;
        }
        catch (System.DivideByZeroException)
        {
            Console.WriteLine(" ERRO 9x21 - ");
            //throw;
        }
        catch (System.Exception)
        {
            Console.WriteLine(" ERRO 9x22 - ");
            //throw;
        }
        finally
        {
            Console.Write("Finalizou!");
        }






        // double a = 0.25;
        // double b = 0.10;
        // double c = 0.05;
        // double d = 0.01;
        // double f = 0;

        // int moedas = 0;
        // do
        // {
        //     Console.WriteLine("valor do troco");
        //     f = Convert.ToDouble(Console.ReadLine());
        // }
        // while (f <= 0);

        // while (f >= a)
        // {
        //     f -= a;
        //     moedas++;
        // }

        // while (f >= b)
        // {
        //     f -= a;
        //     moedas++;
        // }

        // while (f >= c)
        // {
        //     f -= a;
        //     moedas++;
        // }

        // while (f >= d)
        // {
        //     f -= a;
        //     moedas++;
        // }

        // Console.WriteLine($"voce recebera {moedas} moedas");



        // n = 8;
        // for (int i = 0; i < n; i++)
        // {

        //     for (int j = n - i; j >= 0; j--)
        //     {
        //         Console.Write(" ");
        //     }
        //     for (int j = 0; j <= i; j++)
        //     {
        //         Console.Write("#");
        //     }

        //     Console.Write("  ");

        //     for (int j = 0; j <= i; j++)
        //     {
        //         Console.Write("#");
        //     }
        //     Console.WriteLine(" ");


        // }

        // for (int i = 0; i < n; i++)
        // {
        //     for (int j = n - i; j >= 1; j--)
        //     {
        //         Console.Write(" ");
        //     }

        //     for (int j = 0; j <= i; j++)
        //     {
        //         Console.Write("#");
        //     }

        //     Console.Write(" ");

        //     for (int j = 0; j <= i; j++)
        //     {
        //         Console.Write("#");
        //     }
        //     Console.WriteLine(" ");

        // }


    }
}