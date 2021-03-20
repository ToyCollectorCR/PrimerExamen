using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DBO
{
     public class PadronElectoralEntity : En
    {
        public int? IdCivil { get; set; }
        public string Cedula { get; set; }
        public  string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string  Apellido2 { get; set; }
        public int Edad { get; set; }
        public bool Estado { get; set; }
        


    }
}
