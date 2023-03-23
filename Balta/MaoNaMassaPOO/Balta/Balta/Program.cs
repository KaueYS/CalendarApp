using System.Linq;

List<string> alunos = new List<string> { "Kaue", "Jose", "Mario", "Luiz", "Mane", "Luca", "Marcos", "Rivelino", "Rivaldo", "Romario" };

var ordenado = alunos.Order();


foreach (var item in ordenado)
{

    Console.WriteLine("BEM VINDO");
    Console.WriteLine(item);
}

var velocidade = 200;
for (int i = 0; i <= velocidade; i += 25)
{

    Console.WriteLine(i);
}
Console.WriteLine("Atingiu o limite de 200KM/H");



var horaAtual = 17;
if (horaAtual >= 7 && horaAtual <= 17) { Console.WriteLine("Mercado aberto"); } else Console.WriteLine("FECHADO");



