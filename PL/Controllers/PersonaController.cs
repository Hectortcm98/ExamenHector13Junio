using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult GetAll()
        { 
            var result = BLL.Persona.GetAll();
            if (result.Item1 == true)
            {
                ML.Persona persona = result.Item3;
                return View (persona);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Form(int? idPersona)
        {
            ML.Persona persona = new ML.Persona();

            if(idPersona != null)
            {
                var result = BLL.Persona.GetById(idPersona.Value);
                persona = result.Item3;

                return View(persona);
            }
            else
            {
                var result= BLL.Persona.GetAll();
                persona.PersonaList = new ML.Persona().PersonaList;
                persona = result.Item3;
                persona.PersonaList = persona.PersonaList;


                return View(persona);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Persona persona)
        {
            if(persona.IdPersona != 0)
            {
                var updateResult  = BLL.Persona.Update(persona);

                if(updateResult.Item1)
                {
                    ViewBag.Text = "Se ha Actualizado correctamente";
                    return PartialView("Modal");          
                }
                else
                {
                    ViewBag.Text = "No se ha Actualizado correctamente";
                    return PartialView("Modal");
                }
            }
            else
            {
                var addResult = BLL.Persona.Add(persona);
                if (addResult.Item1)
                {
                    ViewBag.Text = "Se agrego correctamente";
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Text = "No se agrego correctamente";
                    return PartialView("Modal");
                }
            }
            
        }


        [HttpGet]
        public ActionResult Delete(int? idPersona)
        {
            ML.Persona persona = new ML.Persona();
            persona.IdPersona = idPersona.Value;

            var deleteResult = BLL.Persona.Delete(persona);
            if (deleteResult.Item1)
            {
                ViewBag.Text = "se ha eliminado correctamente";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Text = "NO se se ha eliminado correctamente";
                return PartialView("Modal");
            }
        }



        [HttpPost]
        public JsonResult AddPersona(ML.Persona persona)
        {

            var result = BLL.Persona.Add(persona);
            if (result.Item1)
            {
                return Json(result.Item3, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result.Item2, JsonRequestBehavior.AllowGet);
            }

        }

    }
}