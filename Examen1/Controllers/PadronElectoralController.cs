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
    public class PadronElectoralController : Controller
    {
        // GET: Padron Electoral
        public ActionResult Index()
        {
            var Empresas = IApp.PadronElectoralServis.ObtenerLista(null);
            if (TempData.ContainsKey("msg")) ViewData["msg"] = TempData["msg"].ToString();
            return View(Empresas);
        }

        public ActionResult Edit(int? id)
        {
            var entity = new PadronElectoralEntity();
            try
            {
                ViewBag.Form = false;
                if (id.HasValue)
                {
                    ViewBag.Form = true;
                    entity = IApp.PadronElectoralServis.ObtenerLista(id).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

            return View(entity);

        }

        [HttpPost]
        public ActionResult Save(PadronElectoralEntity entity)
        {


            try
            {

                var result = new DBEntity();
                if (entity.IdCivil.HasValue)
                {

                    result = IApp.PadronElectoralServis.Actualizar(entity);
                    TempData["msg"] = "Se actualizo el registro con exito!";


                }
                else
                {
                    result = IApp.PadronElectoralServis.Insertar(entity);
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
                var result = IApp.PadronElectoralServis.Eliminar(new PadronElectoralEntity { IdCivil = id });
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