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

            List<Poznamkyy> ListPoznamky = Databaze.Poznamky
            .Where(n => n.Owner == HttpContext.Session.GetString("Jmeno_Prihlaseni"))
            .ToList();


            if (HttpContext.Session.GetString("Jmeno_Prihlaseni") != null || HttpContext.Session.GetString("Jmeno_Prihlaseni") != "")
            {
                ViewData["uzivatel"] = HttpContext.Session.GetString("Jmeno_Prihlaseni");
            }
            return View(ListPoznamky);
        }
        [HttpGet]
        public IActionResult pridat_poznamku()
        {
            if (HttpContext.Session.GetString("Jmeno_Prihlaseni") != null)
            {
                return View();
            }
            ViewData["chyba"] = "První se přihlašte!";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult pridat_poznamku(string nadpis, string text, string Dulezita)
        {
            if (nadpis == null || text == null)
            {
                ViewData["chyba"] = "Nezapomněl jste něco?";
            }
            
            bool Ligma;
            if (Dulezita == string.Empty || Dulezita == null)
            {
                Ligma = false;
            }
            else { Ligma = true; }

            if (HttpContext.Session.GetString("Jmeno_Prihlaseni") != null)
            { 
                Poznamkyy NovaPoznamka = new Poznamkyy()
                {
                    Nadpis = nadpis,
                    Text = text,
                    JeDulezita = Ligma,
                    Owner = HttpContext.Session.GetString("Jmeno_Prihlaseni"),
                    CasPridani = DateTime.Now
                };
                Databaze.Add(NovaPoznamka);
                Databaze.SaveChanges();
                return RedirectToAction("prehled", "Poznamkyy");
            }
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public IActionResult edit(int Id)
        {
            Debug.WriteLine("ČÍSLO ID:");
            Debug.WriteLine(Id);
            Poznamkyy poznamka = Databaze.Poznamky
            .Where(n => n.Id == Id).FirstOrDefault();

            if (poznamka != null && poznamka.Owner == HttpContext.Session.GetString("Jmeno_Prihlaseni")) {return View(poznamka);}
            else {return RedirectToAction("prehled", "Poznamkyy");}
        }

        [HttpGet]
        public IActionResult smazat_poznamku(int Id)
        {
            if (Id == null) { return RedirectToAction("prehled", "Poznamkyy"); }

            Debug.WriteLine("Id: ");
            Debug.WriteLine(Id);

            Poznamkyy poznamka = Databaze.Poznamky
            .Where(n => n.Id == Id).FirstOrDefault();

            Databaze.Remove(poznamka);
            Databaze.SaveChanges();
            
            return RedirectToAction("prehled", "Poznamkyy");
        }
        [HttpPost]
        public IActionResult JeDulezita_idk(int Id)
        {

            Poznamkyy poznamka = Databaze.Poznamky
            .Where(n => n.Id == Id).FirstOrDefault();

            if (poznamka == null) { return RedirectToAction("prehled", "Poznamkyy"); }  

            poznamka.JeDulezita = !poznamka.JeDulezita;
            Databaze.SaveChanges();

            return RedirectToAction("prehled", "Poznamkyy");
        }
        
    }
}