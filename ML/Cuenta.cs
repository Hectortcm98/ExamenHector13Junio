using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cuenta
    {
        public int IdCuenta { get; set; }

        public string NumeroCuenta { get; set;}

        public List<ML.Cuenta>  ListCuenta { get; set;}
        public ML.Banco Banco { get; set; }

        public ML.Persona Persona { get; set; }
    }
}
