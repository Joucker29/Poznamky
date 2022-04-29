using Microsoft.AspNetCore.Mvc;
using Poznamky.Data;
using System.Diagnostics;
using Poznamky.Models;

namespace Poznamky.Controllers
{
    public class PoznamkyyController : Controller
    {
        NasDatovyKontext Databaze { get; }

        public PoznamkyyController(NasDatovyKontext databaze)
        {
            Databaze = databaze;
        }

        [HttpGet]
        public IActionResult prehled()
        {
            
            Users is_prihlasen = Databaze.Users
            .Where(n => n.JePrihlasen == true)
            .FirstOrDefault();


            if (HttpContext.Session.GetString("Jmeno_Prihlaseni") != null || HttpContext.Session.GetString("Jmeno_Prihlaseni") != "")
            {
                ViewData["uzivatel"] = HttpContext.Session.GetString("Jmeno_Prihlaseni");
            }
            return View(); 
        }



    }
}