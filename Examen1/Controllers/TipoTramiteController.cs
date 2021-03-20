using Entity;
using Entity.DBO;
using Examen1.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen1.Controllers
{
    public class TipoTramiteController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            var Empresas = IApp.TipoTramiteServis.ObtenerLista(null);
            if (TempData.ContainsKey("msg")) ViewData["msg"] = TempData["msg"].ToString();
            return View(Empresas);
        }

        public ActionResult Edit(int? id)
        {
            var entity = new TipoTramiteEntity();
            try
            {
                ViewBag.Form = false;
                if (id.HasValue)
                {
                    ViewBag.Form = true;
                    entity = IApp.TipoTramiteServis.ObtenerLista(id).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

            return View(entity);

        }

        [HttpPost]
        public ActionResult Save(TipoTramiteEntity entity)
        {


            try
            {

                var result = new DBEntity();
                if (entity.IdTipoTramite.HasValue)
                {

                    result = IApp.TipoTramiteServis.Actualizar(entity);
                    TempData["msg"] = "Se actualizo el registro con exito!";


                }
                else
                {
                    result = IApp.TipoTramiteServis.Insertar(entity);
                    TempData["msg"] = "Se inserto el registro con exito!";

                }

                if (result.CodeError != 0) throw new Exception(result.MsgError);

                return RedirectToAction("index");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }


        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            try
            {
                var result = IApp.TipoTramiteServis.Eliminar(new TipoTramiteEntity { IdTipoTramite = id });
                TempData["msg"] = "Se elimino el registro con exito!";

                if (result.CodeError != 0) throw new Exception(result.MsgError);

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {


                return Content(ex.Message);
            }



        }






    }
}