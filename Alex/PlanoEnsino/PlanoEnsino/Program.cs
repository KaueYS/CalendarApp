
using System.Text;

Console.WriteLine("Esse software é dedicado ao processamento de arquivos CSV");

string minutosEscolhido = null;
string diasEscolhidos = null;
bool conseguiuConverterPorTempo = false;
bool conseguiuConverterPorDia = false;
int minutoConvertido = 0;
int diasConvertido = 0;
do
{
    Console.Write("Informe o tempo em minutos: ");
    minutosEscolhido = Console.ReadLine();

    if (string.IsNullOrEmpty(minutosEscolhido))
    {
        Console.Write("Informe o tempo em dias: ");
        diasEscolhidos = Console.ReadLine();
    }
    conseguiuConverterPorTempo = int.TryParse(minutosEscolhido, out minutoConvertido);
    conseguiuConverterPorDia = int.TryParse(diasEscolhidos, out diasConvertido);

} while (!conseguiuConverterPorTempo && !conseguiuConverterPorDia);

string pastaPadrao = Directory.GetCurrentDirectory();

string[] arquivosCsv = Directory.GetFiles(pastaPadrao, "*-original.csv");


if(minutoConvertido > 0)
{
    ProcessarPorTempo();
}
else
{
    ProcessarPorDias();
}

void ProcessarPorDias()
{
    foreach (string arquivoCsv in arquivosCsv)
    {
        string[] arquivoLinhas = File.ReadAllLines(arquivoCsv);
        int quantidadeDeVideoPorDia = (int)Math.Ceiling((decimal)arquivoLinhas.Length / diasConvertido);
        int linhaCorte = 1;
        List<string> videoAgrupados = new List<string>();

        foreach (string arquivoLinha in arquivoLinhas)
        {
            
            string[] linhaColunas = arquivoLinha.Split(",");
            // Coluna 1 = nome do video
            // Coluna 2 = branco
            // Coluna 3 = tempo MM:SS

            if (linhaColunas.Length == 0 || linhaColunas[0] == string.Empty)
            {
                continue;
            }

            string nomeVideo = linhaColunas[0];
            string tempoVideo = linhaColunas[2];

            

            if(linhaCorte == quantidadeDeVideoPorDia)
            {
                videoAgrupados.Add(string.Empty);
                linhaCorte= 0;
            }
            videoAgrupados.Add(nomeVideo);
            linhaCorte++;

        }

        StringBuilder stringBuilder = new StringBuilder();

        foreach (string linha in videoAgrupados)
        {
            stringBuilder.AppendLine(linha);
        }

        string nomeArquivoOriginal = Path.GetFileNameWithoutExtension(arquivoCsv);

        nomeArquivoOriginal = $"{nomeArquivoOriginal}-resultado.csv";

        string arquivoFinal = $"{pastaPadrao}\\{nomeArquivoOriginal}";

        if (File.Exists(arquivoFinal))
        {
            File.Delete(arquivoFinal);
        }
        File.WriteAllText(arquivoFinal, stringBuilder.ToString(), Encoding.UTF8);
    }
}

void ProcessarPorTempo()
{
    foreach (string arquivoCsv in arquivosCsv)
    {
        string[] arquivoLinhas = File.ReadAllLines(arquivoCsv);

        int minutosDeQuebra = int.Parse(minutosEscolhido);
        double minutosTotal = 0;
        List<string> videoAgrupados = new List<string>();

        foreach (string arquivoLinha in arquivoLinhas)
        {
            string[] linhaColunas = arquivoLinha.Split(",");
            // Coluna 1 = nome do video
            // Coluna 2 = branco
            // Coluna 3 = tempo MM:SS

            if (linhaColunas.Length == 0 || linhaColunas[0] == string.Empty)
            {
                continue;
            }

            string nomeVideo = linhaColunas[0];
            string tempoVideo = linhaColunas[2];

            string[] tempoVideoSplit = tempoVideo.Split(":");
            if (tempoVideoSplit.Length == 2)
            {
                tempoVideo = $"00:{tempoVideo}";
            }

            TimeSpan tempoVideoSpan = TimeSpan.Parse(tempoVideo);

            minutosTotal += tempoVideoSpan.TotalMinutes;

            if (minutosTotal >= minutosDeQuebra)
            {
                videoAgrupados.Add(string.Empty);
                videoAgrupados.Add(nomeVideo);
                minutosTotal = 0;
                videoAgrupados.Add(string.Empty);
                continue;
            }
            else
            {
                nomeVideo = $"{nomeVideo},{tempoVideo}";
                videoAgrupados.Add(nomeVideo);
            }

        }

        StringBuilder stringBuilder = new StringBuilder();

        foreach (string linha in videoAgrupados)
        {
            stringBuilder.AppendLine(linha);
        }

        string nomeArquivoOriginal = Path.GetFileNameWithoutExtension(arquivoCsv);

        nomeArquivoOriginal = $"{nomeArquivoOriginal}-resultado.csv";

        string arquivoFinal = $"{pastaPadrao}\\{nomeArquivoOriginal}";

        if (File.Exists(arquivoFinal))
        {
            File.Delete(arquivoFinal);
        }
        File.WriteAllText(arquivoFinal, stringBuilder.ToString(), Encoding.UTF8);



    }
}