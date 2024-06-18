using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Persona
    {
        public int? IdPersona { get; set; }
        public string Nombre { get; set; }

        [Display (Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "FechaNa de cimineto")]
        public DateTime FechaNacimineto { get; set; }
        public string PaisOrigen { get; set; }
        public  string Sexo { get; set; }
        public string CURP {  get; set; }
        public string RFC { get; set; }
        public string Ocupacion { get; set; }

        [Display(Name = "Tipo de Persona Moral")]
        public string TipoPersonaFisica { get; set;}

        public List<ML.Persona> PersonaList { get; set; }
    }
}
