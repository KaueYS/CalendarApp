

//Opcao1();
using ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {
        //Opcao2();

        //static void Opcao2()
        //{
        //    List<int> horariosAgendados = new List<int> { 8, 10, 9, 13, 14, 15, 17 };

        //    List<Agendamento> horariosDisponiveis = new List<Agendamento>();

        //    List<Agendamento> consultaHorariosDisponiveis = new List<Agendamento>();

        //    DateTime horas = new DateTime(23, 01, 13, 7, 00, 00);
        //    for (int i = 8; i <= 18; i++)
        //    {
        //        horas = horas.AddMinutes(30);
        //        consultaHorariosDisponiveis.Add(new Agendamento { Start = horas });
        //    }

        //    foreach (var item in consultaHorariosDisponiveis)
        //    {
        //        Agendamento horariosEncontrados = horariosAgendados.Find(x => x == horas);
        //        if (horariosEncontrados == 0)
        //        {
        //            horariosDisponiveis.Add(item);
        //        }

        //    }

        //    return Ok(horariosDisponiveis);

        //}

        //static void Opcao1()
        //{
        //    List<int> todosOsHorariosDoDia = new List<int> { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
        //    List<int> horariosAgendados = new List<int> { 8, 10, 9, 13, 14, 15, 17 };
        //    List<int> horariosDisponiveis = new List<int>();



        //    foreach (var item in todosOsHorariosDoDia)
        //    {
        //        int horariosEncontrados = horariosAgendados.Find(x => x == item);
        //        if (horariosEncontrados == 0)
        //        {
        //            horariosDisponiveis.Add(item);
        //        }

        //    }

        //    foreach (var item in horariosDisponiveis)
        //    {
        //        Console.WriteLine($"Os horarios disponiveis sao {item}");
        //    }
        //}

        Console.Write("números inteiros? ");
        int x = int.Parse(Console.ReadLine());
        
        for (int i = x; i >= 0; i--)
        {
            if(i %2 != 0)
            Console.WriteLine(i);
            
        }
        




    }
}