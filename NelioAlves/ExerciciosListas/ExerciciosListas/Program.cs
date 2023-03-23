
using ExerciciosListas;
using System.Collections.Generic;

//Listas();

//Matrizes();

//Estoque();






static void Listas()
{
    List<Employee> lista = new List<Employee>();

    Console.WriteLine("Quantos funcionarios? :");
    int funcionariosRegistrados = Convert.ToInt32(Console.ReadLine());

    for (int i = 1; i <= funcionariosRegistrados; i++)
    {
        Console.WriteLine("Empregado # " + i);
        i.ToString();

        Console.WriteLine("qual o Id do funcionario? :");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("qual o NOME do funcionario? :");
        string nome = Console.ReadLine();
        Console.WriteLine("qual o salario do funcionario? :");
        decimal salario = Convert.ToDecimal(Console.ReadLine());

        Employee employee = new Employee
        {
            Id = id,
            Nome = nome,
            Salario = salario,
        };

        lista.Add(employee);
    }

    foreach (var item in lista)
    {
        Console.WriteLine(item.MostrarNaTela());
    }
}

static void Matrizes()
{
    int n = int.Parse(Console.ReadLine());
    int[,] mat = new int[n, n];

    for (int i = 0; i < n; i++)
    {
        string[] values = Console.ReadLine().Split(" ");

        for (int j = 0; j < n; j++)
        {
            mat[i, j] = int.Parse(values[j]);
        }
    }

    for (int i = 0; i < n; i++)
    {
        Console.Write(mat[i, i]);
    }

    Console.WriteLine();
    int count = 0;
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            if (mat[i, j] < 0)
            {
                count++;

            }
        }
    }
    Console.WriteLine(count);
}

static void Estoque()
{
    Console.WriteLine("Digite o produto");
    var nome = Console.ReadLine();

    Console.WriteLine("Digite o Valor do Produto");
    var valor = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Digite a quantidade em estoque");
    var quantidade = Convert.ToInt32(Console.ReadLine());

    Produto produtos = new Produto
    {
        Nome = nome,
        Valor = valor,
        Quantidade = quantidade

    };
    Console.WriteLine(produtos);
}