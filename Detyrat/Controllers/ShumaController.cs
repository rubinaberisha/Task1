using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ShumaController : Controller
{
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Index(int shuma)
    {
        if (shuma < 100)
        {
            ViewBag.Rezultati = "Ju lutem shkruani nje shume prej te pakten 100.";
        }
        else
        {
            int[] eurot = { 500, 200, 100, 50, 20, 10, 5 };
            var rezultat = new List<string>();

            foreach (var parat in eurot)
            {
                int sasia = shuma / parat;
                shuma %= parat;
                if (sasia > 0)
                {
                    rezultat.Add($"{sasia} x {parat}€");
                }
            }

            ViewBag.Rezultati = string.Join(", ", rezultat);
        }
        return View();
    }
}
