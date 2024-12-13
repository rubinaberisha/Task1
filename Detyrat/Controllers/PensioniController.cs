using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PensioniController : Controller
{
    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Index(string emri, string mbiemri, DateTime dataLindjes)
    {
        int moshaAktuale = DateTime.Now.Year - dataLindjes.Year;
        if (DateTime.Now < dataLindjes.AddYears(moshaAktuale))
            moshaAktuale--;

        string mesazhi = "";
        int vitePerPension = 65 - moshaAktuale;

        if (vitePerPension < 0)
        {
            mesazhi = $"{emri} {mbiemri}, ke dale ne pension para {Math.Abs(vitePerPension)} vjetesh.";
        }
        else
        {
            mesazhi = $"{emri} {mbiemri}, te duhen edhe {vitePerPension} vjet per te dale ne pension.";
        }

        ViewBag.Mesazhi = mesazhi;
        return View();
    }

}
