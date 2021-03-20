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

    public interface IPadronElectoralService : IDisposable
    {
        List<PadronElectoralEntity> ObtenerLista(int? IdCivil);

        List<PadronElectoralEntity> Obtenerddl();
        DBEntity Insertar(PadronElectoralEntity entity);
        DBEntity Actualizar(PadronElectoralEntity entity);
        DBEntity Eliminar(PadronElectoralEntity entity);
    }
    public class PadronElectoralService : IPadronElectoralService
    {
        public IBD sql = new BD("Conn");

        public void Dispose()
        {
            sql = null;
        }

        public List<PadronElectoralEntity> ObtenerLista(int? IdCivil)
        {
            try
            {
                var result = sql.Query<PadronElectoralEntity>("PadronElectoralObtener", new
                {
                    IdCivil
                });
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<PadronElectoralEntity> Obtenerddl()
        {
            try
            {
                var result = sql.Query<PadronElectoralEntity>("PadronElectoralListar");
                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }





        public DBEntity Insertar(PadronElectoralEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("PadronElectoralInsertar", new
                {
                    entity.Cedula,
                    entity.Nombre,
                    entity.Apellido1,
                    entity.Apellido2,
                    entity.Edad,
                    entity.Estado

                });

                return result;

            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }

        public DBEntity Actualizar(PadronElectoralEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("PadronElectoralActualizar", new
                {
                    entity.IdCivil,
                    entity.Cedula,
                    entity.Nombre,
                    entity.Apellido1,
                    entity.Apellido2,
                    entity.Edad,
                    entity.Estado

                });


                return result;
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }
        }

        public DBEntity Eliminar(PadronElectoralEntity entity)
        {
            try
            {
                var result = sql.QueryExecute("PadronElectoralEliminar", new
                {
                    entity.IdCivil


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
