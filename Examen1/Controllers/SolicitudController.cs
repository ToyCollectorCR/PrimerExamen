using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen1.App;
using Entity.DBO;
using Examen1.Models;

namespace Examen1.Controllers
{
    public class SolicitudController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            var Empleados = IApp.solicitudServis.ObtenerLista(null);
            if (TempData.ContainsKey("msg")) ViewData["msg"] = TempData["msg"].ToString();
            return View(Empleados);
        }

        public ActionResult Edit(int? id)
        {

            var entity = new SolicitudEdit() { solicitud = new SolicitudEntity() };


            try
            {
                ViewBag.Form = false;
                if (id.HasValue)
                {
                    ViewBag.Form = true;
                    entity.solicitud = IApp.solicitudServis.ObtenerDetalle(id);

                }

                entity.ddlPadronElectoral = IApp.PadronElectoralServis.Obtenerddl();
                entity.ddlTipoTramite = IApp.TipoTramiteServis.Obtenerddl();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

            return View(entity);
        }

        [HttpPost]
        public ActionResult Save(SolicitudEntity entity)
        {

            try
            {
                var result = new DBEntity();

                if (entity.IdSolicitud.HasValue)
                {

                    result = IApp.solicitudServis.Actualizar(entity);


                }

                else
                {
                    result = IApp.solicitudServis.Insertar(entity);
                }

                return Json(result);

            }
            catch (Exception ex)
            {

                return Json(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            try
            {
                var result = IApp.solicitudServis.Eliminar(new SolicitudEntity { IdSolicitud = id });
                TempData["msg"] = "0";

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