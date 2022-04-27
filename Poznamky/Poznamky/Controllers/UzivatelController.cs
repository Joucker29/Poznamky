using Microsoft.AspNetCore.Mvc;
using Poznamky.Data;
using System.Diagnostics;
using Poznamky.Models;

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
            if (jmeno == null)
            {
                Debug.WriteLine("CHYBA");
                ViewData["chyba"] = "Máš špatně napsané jméno!";
                return View();
            }
            Users SameUser = Databaze.Users
            .Where(n => n.Jmeno == jmeno)
            .FirstOrDefault();


            Users SameMail = Databaze.Users
            .Where(u => u.Mail == email)
            .FirstOrDefault();

            if (SameUser == null && SameMail == null)
            {
                Users newUser = new Users()
                {
                    Jmeno = jmeno,
                    Mail = email,
                    Heslo_hashed = BCrypt.Net.BCrypt.HashPassword(heslo)
                };
                Databaze.Add(newUser);
                Databaze.SaveChanges();
                return RedirectToAction("prihlaseni", "Uzivatel");
            }


            return View();
        }
    }       
}