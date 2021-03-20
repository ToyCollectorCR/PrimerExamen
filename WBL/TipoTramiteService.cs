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

    public interface ITipoTramiteService : IDisposable
    {
        List<TipoTramiteEntity> ObtenerLista(int? IdTipoTramite);

        List<TipoTramiteEntity> Obtenerddl();
        DBEntity Insertar(TipoTramiteEntity entity);
        DBEntity Actualizar(TipoTramiteEntity entity);
        DBEntity Eliminar(TipoTramiteEntity entity);
    }
    public class TipoTramiteService : ITipoTramiteService
    {
        public IBD sql = new BD("Conn");

        public void Dispose()
        {
            sql = null;
        }

        public List<TipoTramiteEntity> ObtenerLista(int? IdTipoTramite)
        {
            try
            {
                var result = sql.Query<TipoTramiteEntity>("TipoTramiteObtener", new
                {
                    IdTipoTramite
                });
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<TipoTramiteEntity> Obtenerddl()
        {
            try
            {
                var result = sql.Query<TipoTramiteEntity>("TipoTramiteListar");
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }





        public DBEntity Insertar(TipoTramiteEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("TipoTramiteInsertar", new
                {
                    Descripcion = entity.Descripcion,
                    entity.Estado

                });

                return result;

            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }

        public DBEntity Actualizar(TipoTramiteEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("TipoTramiteActualizar", new
                {
                    entity.IdTipoTramite,
                    entity.Descripcion,
                    entity.Estado

                });


                return result;
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        public DBEntity Eliminar(TipoTramiteEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("TipoTramiteEliminar", new
                {
                    entity.IdTipoTramite


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
