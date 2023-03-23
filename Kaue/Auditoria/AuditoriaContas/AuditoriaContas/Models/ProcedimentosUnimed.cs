namespace AuditoriaContas.Models
{
    public class ProcedimentosUnimed
    {

        public string Beneficiario { get; set; }
        public string Data { get; set; }

        public string Procedimento { get; set; }

        public string Honorario { get; set; }

        public string Prestador { get; set; }

        public bool BeneficiarioEncontrado { get; set; }

    }

}
   


//0-GUIA;
//1-CONTA;
//2-CODIGO;
//3-BENEFICIARIO;
//4-DATA ATENDIMENTO;
//5-DATA UTILIZACAO;
//6-CODIGO PROCEDIMENTO;
//7-NOME PROCEDIMENTO;
//8-FUNCAO;
//9-QUANTIDADE;
//10-CUSTO;
//11-FILME;
//12-HONORARIO;
//13-GLOSA;
//14-COD_GLOSA;
//15-TOTAL;
//16-VALOR INFORMADO;
//17-LOCAL ATENDIMENTO;
//18-PRESTADOR ARQUIVO