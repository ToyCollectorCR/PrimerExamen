using Entity.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen1.Models
{
    public class SolicitudEdit
    {
        public SolicitudEntity solicitud { get; set; }
        public List<PadronElectoralEntity> ddlPadronElectoral { get; set; }

        public List<TipoTramiteEntity> ddlTipoTramite { get; set; }
    }
}