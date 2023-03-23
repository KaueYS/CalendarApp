using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudar
{
    public partial class Estudo : Form
    {
        public Estudo()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string pastaPadrao = Directory.GetCurrentDirectory();

            string[] arquivosCsv = Directory.GetFiles(pastaPadrao, "*-original.csv");

            foreach (string arquivoCsv in arquivosCsv)
            {
                string[] arquivoLinhas = File.ReadAllLines(arquivoCsv);

                int minutosDeQuebra = int.Parse(cbMinutos.Text);
                double minutosTotal = 0;
                List<string> videosAgrupados = new List<string>();



                foreach (string arquivoLinha in arquivoLinhas)
                {
                    string[] linhaColunas = arquivoLinha.Split(',');
                    // Coluna 1 = nome do video
                    // Coluna 2 = branco
                    // Coluna 3 = tempo MM:SS

                    if (linhaColunas.Length == 0 || linhaColunas[0] == string.Empty)
                    {
                        continue;
                    }

                    string nomeVideo = linhaColunas[0];
                    string tempoVideo = linhaColunas[2];

                    string[] tempoVideoSplit = tempoVideo.Split(':');
                    if (tempoVideoSplit.Length == 2)
                    {
                        tempoVideo = $"00:{tempoVideo}";
                    }

                    TimeSpan tempoVideoSpan = TimeSpan.Parse(tempoVideo);

                    minutosTotal += tempoVideoSpan.TotalMinutes;


                    if (minutosTotal >= minutosDeQuebra)
                    {
                        videosAgrupados.Add(nomeVideo);

                        videosAgrupados.Add(string.Empty);
                        minutosTotal = 0;
                        continue;
                    }
                    videosAgrupados.Add(nomeVideo);
                }

                List<EstudarVO> listaVO = new List<EstudarVO>();
                for (int i = 0; i < videosAgrupados.Count; i++)
                {
                    EstudarVO vo = new EstudarVO();

                    vo.NomeVideo = videosAgrupados[i];


                    listaVO.Add(vo);
                }
                grdResumoDosCursos.DataSource = listaVO;


                StringBuilder stringBuilder = new StringBuilder();

                foreach (string linha in videosAgrupados)
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

    }
}


