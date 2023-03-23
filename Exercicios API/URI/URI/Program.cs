
using System.Globalization;

using System;


        var TempoOtimista = new TimeSpan(2, 15, 40);
        var TempoProvavel = new TimeSpan(2, 14, 10);
        var TempoPessimista = new TimeSpan(2, 16, 40);
        var TempoRevisado = new TimeSpan();
        TempoRevisado = new TimeSpan(0, 0, (int)(TempoOtimista + TempoProvavel + TempoPessimista).TotalSeconds / 3);
        Console.WriteLine(TempoRevisado);


//===================================================================
int x = int.Parse(Console.ReadLine());

if (x % 2 == 0)
{
    x++;
}

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(x);
    x += 2;
}

//=================================================================

//int a, b, c;

//string[] sort = Console.ReadLine().Split(" ");
//a = int.Parse(sort[0]);
//b = int.Parse(sort[1]);
//c = int.Parse(sort[2]);



//Console.WriteLine($" {a} {b} {c}");


//int a = int.Parse(Console.ReadLine());
//int b = int.Parse(Console.ReadLine());
//int c = int.Parse(Console.ReadLine());
//int d = int.Parse(Console.ReadLine());

//if (b > c && d > a)
//{
//    if ((c + d) > (a + b))
//    {
//        if (c > 0 && d > 0)
//        {
//            if (a % 2 == 0)
//            {
//                Console.WriteLine("Valores aceitos");
//            }

//        }

//    }
//}
//else
//{
//    Console.WriteLine("Valores nao aceitos");
//}


//double a, b, c, res, raiza, raizb, raizc;

//a = double.Parse(Console.ReadLine());
//b = double.Parse(Console.ReadLine());
//c = double.Parse(Console.ReadLine());
//res = Math.Pow(a, 2.0) + Math.Pow(b, 2.0) + Math.Pow(c, 2.0);

//if (res <= 0)
//{
//    Console.WriteLine("IMPOSSIVEL CAlcular");
//}
//else
//{
//    Console.WriteLine($" {res}");
//}


//if-else

//double nota1 = double.Parse(Console.ReadLine());
//double nota2 = double.Parse(Console.ReadLine());
//double soma = nota1 + nota2;

//if (soma > 60)
//{
//    Console.WriteLine("APROVADO");

//}
//else Console.WriteLine("REPROVADO");


//double area;
//double p = 3.14159;
//double raio = 150;

//area = p * Math.Pow(raio, 2);

//Console.WriteLine(area.ToString("F4", CultureInfo.InvariantCulture));


//string nome = Console.ReadLine();
//double salario = double.Parse(Console.ReadLine());
//double vendas = double.Parse(Console.ReadLine());
//double total;

//total = (vendas * 15/100) + salario;

//Console.WriteLine($"TOTAL = {total.ToString("F2")}");


//double troco = 0;
//double valor = 1560;
//double nota100 = 100;
//double nota50 = 50;
//double nota20 = 20;
//double nota10 = 10;
//double nota5 = 5;
//double nota2 = 2;

//double moeda1 = 1;
//double moeda2 = 0.50;
//double moeda3 = 0.10;
//double moeda4 = 0.05;
//double moeda5 = 0.01;

//while(valor > nota100)
//{
//    valor = valor - nota100;
//    troco++;
//}

//Console.WriteLine(troco);
//double res = (valor % nota100);
//double res2 = res% nota50;
//double res3 = res2% nota20;
//double res4 = res3% nota10;
//double res5 = res4% nota5;
//double res6 = res5% nota2;

//double res7 = res6 % moeda1;
//double res8 = res7 % moeda2;
//double res9 = res8 % moeda3;
//double res10 = res9 % moeda4;
//double res11 = res10 % moeda5;

//Console.WriteLine($"{res} {res2} {res3} {res4} {res5} {res6} {res7}, {res8}, {res9}, {res10}");