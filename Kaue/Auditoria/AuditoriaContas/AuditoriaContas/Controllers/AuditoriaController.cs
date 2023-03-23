using AuditoriaContas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace AuditoriaContas.Controllers
{
    public class AuditoriaController : Controller
    {
        private readonly IConfiguration configuration;

        public AuditoriaController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult File()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> FileUpload(List<IFormFile> files)
        {
            List<string> lines = new List<string>();
            List<string> filePaths = new List<string>();
            await UploadArquivos(files, lines, filePaths);

            List<ProcedimentosUnimed> procedimentosUnimed = new List<ProcedimentosUnimed>();
            ListarProcedimentosUnimed(lines, procedimentosUnimed);
            

            List<ProcedimentoClinica> listaProcedimentoClinica = ListarProcedimentosClinica();

            foreach (var unimed in procedimentosUnimed)
            {
                ProcedimentoClinica procedimentoClinica = listaProcedimentoClinica.Find(x => x.Paciente == unimed.Beneficiario);
                if(procedimentoClinica != null)
                {
                    unimed.BeneficiarioEncontrado = true;

                    //if(unimed.Honorario == procedimentoClinica.Valor)
                    //{

                    //}
                }
            }

            return Ok(procedimentosUnimed.Where(x => x.BeneficiarioEncontrado != true).ToList());
        }

        private static async Task UploadArquivos(List<IFormFile> files, List<string> lines, List<string> filePaths)
        {
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // full path to file in temp location
                    var filePath = Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.

                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8, true))
                    {
                        string line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        int i = 0; // jump line 1
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (i <= 1)
                            {
                                i++;
                                continue;
                            }
                            i++;
                            lines.Add(line);
                        }
                    }
                    System.IO.File.Delete(filePath);
                }
            }
        }

        private static void ListarProcedimentosUnimed(List<string> lines, List<ProcedimentosUnimed> procedimentos)
        {

            ProcedimentosUnimed procedimento;
            for (int i = 0; i < lines.Count; i++)
            {
                

                string line = lines[i].ToString();
                string[] parts = line.Split(';');

                if (parts.Length == 1)
                    continue;
                procedimento = new ProcedimentosUnimed();
                procedimento.Beneficiario = parts[3].Trim();
                procedimento.Data = parts[4].Trim();
                procedimento.Procedimento = parts[7].Trim();
                procedimento.Honorario = parts[12].Trim();
                procedimento.Prestador = parts[17].Trim();
                procedimentos.Add(procedimento);
            }
        }

        public List<ProcedimentoClinica> ListarProcedimentosClinica()
        {
            List<ProcedimentoClinica> procedimentosClinica = new List<ProcedimentoClinica>();
            ProcedimentoClinica procedimentoClinica;
            var caminhoDemonstrativoClinica = this.configuration.GetSection("Arquivos:DemonstrativoClinica").Value;


            string[] lines = System.IO.File.ReadAllLines(caminhoDemonstrativoClinica);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].ToString();
                string[] parts = line.Split(';');
                if (parts.Length == 1)
                    continue;
                
                procedimentoClinica = new ProcedimentoClinica();
                procedimentoClinica.Paciente = parts[1].Trim();
                //procedimentoClinica.Procedimento = parts[1].Trim();
                procedimentoClinica.Valor = parts[6].Trim();

                procedimentosClinica.Add(procedimentoClinica);

                
            }
            return procedimentosClinica;
        }
    }
}



