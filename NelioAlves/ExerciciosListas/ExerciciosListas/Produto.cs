using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosListas
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Valor { get; set;}
        public int Quantidade { get; set;}


        public double valorTotal()
        {
            return Valor * Quantidade;
        }

        public override string ToString()
        {
            return Nome + ", \n" + Valor + ",\n" + Quantidade + ", \n" + valorTotal().ToString();
        }
    }
}
