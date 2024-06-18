using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class CuentaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            return View();  
        }

        public JsonResult Get() {
            var result = BLL.Cuenta.GetAllEF();
            if (result.Item1 == true)
            {
                ML.Cuenta cuenta = result.Item3;
                return Json(cuenta, JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllBanco()
        {
            var result = BLL.Banco.GetAll();
            if (result.Item1 == true)
            {
                ML.Banco banco = result.Item3;
                return Json(banco, JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddCuenta(ML.Cuenta cuenta)
        {
            var result = BLL.Cuenta.Add(cuenta);
            if (result.Item1 == true)
            {
                ML.Cuenta cuenta1 = result.Item3;
                return Json(cuenta1, JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost] 
        public JsonResult Delete(int IdCuenta)
        {
            var result = BLL.Cuenta.Delete(IdCuenta);
            if (result.Item1 == true)
            {
                
                return Json(result.Item1, JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        

    }
}