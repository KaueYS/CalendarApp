using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExerciciosListas
{
    public class Employee
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }

        public string MostrarNaTela()
        {
            return Id
            + ", "
            + Nome
            + ", "
            + Salario.ToString("F2");
        }


        public override string ToString()
    {
        return Id
            + ", "
            + Nome
            + ", "
            + Salario.ToString("F2");
    }
    }

}
