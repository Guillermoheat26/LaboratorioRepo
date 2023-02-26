using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio.Models;
using Laboratorio.Models.ViewModels;

namespace Laboratorio.Controllers
{
    public class TecnicoController : Controller
    {
        // GET: Tecnico
        public ActionResult Index()
        {
            List<ListTecnicoViewModel> lst;
            using (LABEntities db = new LABEntities())
            {
                lst = (from d in db.Tecnico
                       select new ListTecnicoViewModel
                       {
                           id_tecnico = d.id_tecnico,
                           nombre = d.nombre,
                           codigo = d.codigo,
                           sueldo_base = d.sueldo_base
                       }).ToList();


            }

            return View(lst);
        }

        public JsonResult Listar()
        {

            List<v_Tecnico_Suc_Ele> oLstTecnicos = new List<v_Tecnico_Suc_Ele>();

            using (LABEntities1 db = new LABEntities1())
            {

                oLstTecnicos = (from p in db.v_Tecnico_Suc_Ele
                                select p).ToList();
            }
            return Json(new { data = oLstTecnicos }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarSucursales()
        {

            List<string> oLstSucursal = new List<string>();

            using (LABEntities1 db = new LABEntities1())
            {

                oLstSucursal = (from p in db.Sucursal
                                select p.id_sucursal+" - "+ p.codigo + " - " + p.nombre).ToList();

            }
            return Json(new { data = oLstSucursal }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarElementos()
        {

            List<Elementos> oLstElementos = new List<Elementos>();

            using (LABEntities1 db = new LABEntities1())
            {

                oLstElementos = (from p in db.Elementos
                                select p).ToList();

            }
            return Json(new { data = oLstElementos }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Obtener(int idtecnico)
        {
            List<v_Tecnico_Suc_Ele> oLstTecnicos = new List<v_Tecnico_Suc_Ele>();

            using (LABEntities1 db = new LABEntities1())
            {

                oLstTecnicos = (from p in db.v_Tecnico_Suc_Ele.Where(x => x.id_tecnico == idtecnico)
                                select p).ToList();
            }

            return Json(oLstTecnicos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(v_Tecnico_Suc_Ele oTecnico)
        {

            bool respuesta = true;
            try
            {
                //PARA NUEVO TECNICO
                if (oTecnico.id_tecnico == 0)
                {
                    using (LABEntities1 db = new LABEntities1())
                    {
                        Tecnico tempTecnico = (from p in db.Tecnico
                                               where p.id_tecnico == oTecnico.id_tecnico
                                               select p).FirstOrDefault();

                        Tecnico_Sucursal tempTecnicoSucursal = (from p in db.Tecnico_Sucursal
                                                                where p.id_tecnico == oTecnico.id_tecnico
                                                                select p).FirstOrDefault();

                        Sucursal tempSucursal = (from p in db.Sucursal
                                                 where p.nombre == oTecnico.nombre_sucursal
                                                 select p).FirstOrDefault();

                        Tecnico_Elementos tempTecnicoElementos = (from p in db.Tecnico_Elementos
                                                                  where p.id_tecnico == oTecnico.id_tecnico
                                                                  select p).FirstOrDefault();

                        tempTecnico.nombre = oTecnico.nombre;
                        tempTecnico.codigo = oTecnico.codigo;
                        tempTecnico.sueldo_base = oTecnico.sueldo_base;
                        tempTecnicoSucursal.id_sucursal = tempSucursal.id_sucursal;
                        //FALTA ELEMENTOS Y CANTIDAD
                        //tempTecnicoElementos.id_elemento;
                        //tempTecnicoElementos.cantidad;

                        db.v_Tecnico_Suc_Ele.Add(oTecnico);
                        db.SaveChanges();
                    }
                }
                //PARA ACTUALIZAR TECNICO
                else
                {
                    using (LABEntities1 db = new LABEntities1())
                    {
                        Tecnico tempTecnico = (from p in db.Tecnico
                                               where p.id_tecnico == oTecnico.id_tecnico
                                               select p).FirstOrDefault();

                        Tecnico_Sucursal tempTecnicoSucursal = (from p in db.Tecnico_Sucursal
                                                                where p.id_tecnico == oTecnico.id_tecnico
                                                                select p).FirstOrDefault();

                        Sucursal tempSucursal = (from p in db.Sucursal
                                                 where p.nombre == oTecnico.nombre_sucursal
                                                 select p).FirstOrDefault();

                        Tecnico_Elementos tempTecnicoElementos = (from p in db.Tecnico_Elementos
                                                 where p.id_tecnico == oTecnico.id_tecnico
                                                 select p).FirstOrDefault();

                        tempTecnico.nombre = oTecnico.nombre;
                        tempTecnico.codigo = oTecnico.codigo;
                        tempTecnico.sueldo_base = oTecnico.sueldo_base;
                        tempTecnicoSucursal.id_sucursal = tempSucursal.id_sucursal;
                        //FALTA ELEMENTOS Y CANTIDAD
                        //tempTecnicoElementos.id_elemento;
                        //tempTecnicoElementos.cantidad;

                        db.SaveChanges();
                    }

                }
            }
            catch
            {
                respuesta = false;

            }

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Eliminar(int idtecnico)
        {
            bool respuesta = true;
            try
            {
                using (LABEntities1 db = new LABEntities1())
                {
                    Tecnico tempTecnico = (from p in db.Tecnico
                                           where p.id_tecnico == idtecnico
                                           select p).FirstOrDefault();

                    Tecnico_Sucursal tempTecnicoSucursal = (from p in db.Tecnico_Sucursal
                                                            where p.id_tecnico ==idtecnico
                                                            select p).FirstOrDefault();

                    Tecnico_Elementos tempTecnicoElementos = (from p in db.Tecnico_Elementos
                                                              where p.id_tecnico == idtecnico
                                                              select p).FirstOrDefault();

                    db.Tecnico.Remove(tempTecnico);
                    db.Tecnico_Sucursal.Remove(tempTecnicoSucursal);
                    db.Tecnico_Elementos.Remove(tempTecnicoElementos);
                    db.SaveChanges();
                }
            }
            catch
            {
                respuesta = false;
            }



            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }




    }
}