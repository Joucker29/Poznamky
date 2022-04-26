using Microsoft.AspNetCore.Mvc;
using Poznamky.Data;
using System.Diagnostics;

namespace Poznamky.Controllers
{
    public class UzivatelController : Controller
    {

        NasDatovyKontext Databaze { get; }

        public UzivatelController(NasDatovyKontext databaze)
        {
            Databaze = databaze;
        }

        [HttpGet]
        public IActionResult prihlaseni()
        {
            return View();
        }
        [HttpGet]
        public IActionResult registrovani()
        {
            return View();
        }

        [HttpPost]
        public IActionResult registrovani(string jmeno, string heslo, string email)
        {
            Debug.Write(jmeno);
            if (jmeno == null)
            {
                Debug.WriteLine("CHYBA");
                ViewData["chyba"] = "Máš špatně napsané jméno!";
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}