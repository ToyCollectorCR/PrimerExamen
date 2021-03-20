using DataAccess;
using Entity;
using Entity.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ISolicitudService : IDisposable
    {
        List<SolicitudEntity> ObtenerLista(int? IdSolicitud);

        SolicitudEntity ObtenerDetalle(int? IdSolicitud);
        DBEntity Insertar(SolicitudEntity entity);
        DBEntity Actualizar(SolicitudEntity entity);
        DBEntity Eliminar(SolicitudEntity entity);
    }

    public class SolicitudService : ISolicitudService
    {
        public IBD sql = new BD("Conn");

        public void Dispose()
        {
            sql = null;
        }

        public List<SolicitudEntity> ObtenerLista(int? IdSolicitud)
        {
            try
            {
                var result = sql.Query<SolicitudEntity, PadronElectoralEntity, TipoTramiteEntity>("SolicitudObtener","IdCivil,IdTipoTramite", new
                {
                    IdSolicitud
                });
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public SolicitudEntity ObtenerDetalle(int? IdSolicitud)
        {

            try
            {
                var result = sql.QueryFirst<SolicitudEntity>("SolicitudObtener", new
                {
                    IdSolicitud
                });
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        public DBEntity Insertar(SolicitudEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("SolicitudInsertar", new
                {
                    entity.IdCivil,
                    entity.IdTipoTramite,
                    entity.detalle,
                    entity.Estado

                });

                return result;

            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }

        public DBEntity Actualizar(SolicitudEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("SolicitudActualizar", new
                {
                    entity.IdSolicitud,
                    entity.IdCivil,
                    entity.IdTipoTramite,
                    entity.detalle,
                    entity.Estado

                });


                return result;
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        public DBEntity Eliminar(SolicitudEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("SolicitudEliminar", new
                {
                    entity.IdSolicitud


                });


                return result;
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }
    }
}
