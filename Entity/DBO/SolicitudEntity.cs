using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DBO
{
    public class SolicitudEntity: En
    {
        public int? IdSolicitud { get; set; }

        public int? IdCivil { get; set; }

        //Foreign Key

        public PadronElectoralEntity padronelec { get; set;  }
        public int? IdTipoTramite { get; set; }
        public TipoTramiteEntity tipotram { get; set; }
        public string detalle { get; set; }

        public bool Estado { get; set; }

        public SolicitudEntity()
        {
            padronelec = padronelec ?? new PadronElectoralEntity();
            tipotram = tipotram ?? new TipoTramiteEntity();
        }

    
    }
}
