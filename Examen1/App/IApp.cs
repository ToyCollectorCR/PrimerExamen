using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WBL;

namespace Examen1.App
{
    public struct IApp
    {
        public static ISolicitudService solicitudServis => new SolicitudService();

        public static IPadronElectoralService PadronElectoralServis => new PadronElectoralService();

        public static ITipoTramiteService TipoTramiteServis => new TipoTramiteService();
    }
}