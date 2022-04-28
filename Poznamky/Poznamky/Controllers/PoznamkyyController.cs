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
            return View();
        }
    }
}
