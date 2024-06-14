using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Persona
    {
        public int? IdPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public DateTime FechaNacimineto { get; set; }
        public string PaisOrigen { get; set; }
        public  string Sexo { get; set; }
        public string CURP {  get; set; }
        public string RFC { get; set; }
        public string Ocupacion { get; set; }

        public string TipoPersonaFisica { get; set;}

        public List<ML.Persona> PersonaList { get; set; }
    }
}
