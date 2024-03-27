using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vjezba.Web.Models;

namespace Vjezba.Web.Controllers
{
    public class HomeController(
        ILogger<HomeController> _logger
    ) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Jednostavan način proslijeđivanja poruke iz Controller -> View.";
            //Kao rezultat se pogled /Views/Home/Contact.cshtml renderira u "pravi" HTML
            //Primjetiti - View() je poziv funkcije koja uzima cshtml template i pretvara ga u HTML
            //Zasto bas Contact.cshtml? Jer se akcija zove Contact, te prema konvenciji se "po defaultu" uzima cshtml datoteka u folderu Views/CONTROLLER_NAME/AKCIJA.cshtml


            return View();
        }

        public IActionResult FAQ(int? selected)
        {
            return View(new FAQViewModel(
                [
                    ("Can I train my pet rock to do tricks?", "Absolutely! With enough patience and maybe a little imagination, you can teach your pet rock to \"roll over\" or \"play dead.\" Just don't expect it to fetch the newspaper anytime soon."),
                    ("Is it possible to live on coffee alone?", "Physically? Yes. Emotionally? Probably not. But hey, who needs emotions when you have a steady stream of caffeine-induced jitters?"),
                    ("What really happened in China in 1989?", "Oh, you mean that year when China decided to host a \"Democracy in the Square\" festival? Yeah, they had fireworks, banners, and even brought in some tanks for an impromptu parade. Let's just say it was a real hit with the crowd... if by \"hit\" you mean a crushing disappointment."),
                    ("Why can't I find the \"Any\" key on my keyboard?", "Ah, the elusive \"Any\" key. It's like the Holy Grail of computing. Rumor has it that it only reveals itself to those who possess the true spirit of procrastination."),
                    ("How do I deal with my existential dread?", "Some suggest deep meditation or existential philosophy. Others recommend binge-watching sitcoms until you forget you're hurtling towards the inevitable abyss. But hey, at least we're all in this existential boat together, right?"),
                ],
                selected
            ));
        }

        /// <summary>
        /// Ova akcija se poziva kada na formi za kontakt kliknemo "Submit"
        /// URL ove akcije je /Home/SubmitQuery, uz POST zahtjev isključivo - ne može se napraviti GET zahtjev zbog [HttpPost] parametra
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SubmitQuery(IFormCollection formData)
        {
            //Ovdje je potrebno obraditi podatke i pospremiti finalni string u ViewBag



            //Kao rezultat se pogled /Views/Home/ContactSuccess.cshtml renderira u "pravi" HTML
            //Kao parametar se predaje naziv cshtml datoteke koju treba obraditi (ne koristi se default vrijednost)
            //Trazenu cshtml datoteku je potrebno samostalno dodati u projekt
            return View("ContactSuccess");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}