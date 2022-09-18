using Nature.App_Data;
using Nature.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nature.Controllers
{
    public class HomeController : Controller
    {
        private readonly NatureContext _context = new NatureContext();
        public ActionResult Index()
        {
            
            return View();
        }

        //public ActionResult Add()
        //{
        //    return View();
        //}

        //public ActionResult Add(SerVivo model)
        //{
        //    var imageType = new String[]
        //    {
        //        "image/gif",
        //        "image/jpeg",
        //        "image/pjpeg",
        //        "image/png"
        //    };

        //    if (ModelState.IsValid)
        //    {
        //        _context.Sers.Add(model);
        //        _context.SaveChanges();

        //        return RedirectToAction("Add");
        //    }

        //    return View(model);
        //}
    }
}
