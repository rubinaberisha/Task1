using Detyrat.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detyrat.Controllers
{
    public class QytetiController : Controller
    {

        private readonly ApplicationDbContext _context;

        public QytetiController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public IActionResult Index(int id)
        //{

        //    string qyteti = "";

        //    switch (id)
        //    {
        //        case 1:
        //            qyteti = "Ulqin";
        //            break;
        //        case 2:
        //            qyteti = "Tivar";
        //            break;
        //        default:
        //            qyteti = "Unknown";
        //            break;
        //    }


        //    ViewBag.Qyteti = qyteti;
        //    return View();
        //}


        public IActionResult Index()
        {
            var cities = _context.Qyteti.Select(q => new { q.Id, q.Emri }).ToList();
            ViewBag.Cities = cities;

            return View();
        }

        [Route("qyteti/historia/{id}")]
        public IActionResult Historia(int id)
        {
            var qyteti = _context.Qyteti.FirstOrDefault(q => q.Id == id);

            if (qyteti == null)
            {
                ViewBag.Historia = "Historia e qytetit nuk eshte e disponueshme.";
            }
            else
            {
                ViewBag.Historia = qyteti.Historia;
            }
           
            return View();
        }


        [Route("qyteti/{id}")]
        public IActionResult Details(int id)
        {
            var qyteti = _context.Qyteti.FirstOrDefault(q => q.Id == id);

            if (qyteti == null)
            {
                return NotFound("Qyteti nuk u gjet.");
            }

            ViewBag.Qyteti = qyteti.Emri;
            ViewBag.HistoriaUrl = Url.Action("Historia", "Qyteti", new { id });

            return View();
        }


    }
}
