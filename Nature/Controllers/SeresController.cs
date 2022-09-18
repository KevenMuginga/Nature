using Nature.App_Data;
using Nature.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nature.Controllers
{
    public class SeresController : Controller
    {
        private readonly NatureContext _context = new NatureContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            var ser = _context.Sers.ToList();
            return View(ser);
        }

        public ActionResult Add()
        {
            ViewBag.Genero = _context.Gens;
            return View();
        }

        [HttpPost]
        public ActionResult Add(SerViewModel model)
        {
            var imageType = new String[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "Campo Obgrigatorio");
            }
            else if (!imageType.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Escolha um tipo GIF, PNG, JPEG");
            }

            if (ModelState.IsValid)
            {

                var ser = new SerVivo();

                ser.Nome = model.Nome;
                ser.Ambiente = model.Ambiente;
                ser.Caracteristicas = model.Caracteristicas;
                ser.Genero = model.Genero;
                ser.GeneroId = model.GeneroId;

                using (var binaryRead = new BinaryReader(model.ImageUpload.InputStream))
                    ser.Imagem = binaryRead.ReadBytes(model.ImageUpload.ContentLength);

                _context.Sers.Add(ser);
                _context.SaveChanges();

                return RedirectToAction("Listar", "Seres");
            }

            ViewBag.Genero = _context.Gens;

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SerVivo ser = _context.Sers.Find(id);
            if (ser == null)
            {
                return HttpNotFound();
            }

            ViewBag.Genero = _context.Gens;
            return View(ser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Nome, Caracteristicas, Ambiente, GeneroId")] SerVivo model)
        {
            if (ModelState.IsValid)
            {
                var produto = _context.Sers.Find(model.Id);
                if (produto == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                produto.Nome = model.Nome;
                produto.Caracteristicas = model.Caracteristicas;
                produto.Ambiente = model.Ambiente;
                produto.GeneroId = model.GeneroId;


                _context.SaveChanges();

                return RedirectToAction("Listar", "Seres");
            }

            ViewBag.Genero = _context.Gens;
            return View(model);
        }

        public ActionResult Delete(int id)
        {

            var produto = _context.Sers.Find(id);
            _context.Sers.Remove(produto);

            _context.SaveChanges();

            return RedirectToAction("Listar", "Seres");
        }

        public ActionResult AddGenero()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGenero(Genero model)
        {
            if (ModelState.IsValid)
            {
                _context.Gens.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Frutos()
        {
            var seres = from s in _context.Sers select s;

            seres = seres.Where(v => v.Genero.GeneroNome.Contains("Fruto"));

            return View(seres.AsEnumerable());
        }

        public ActionResult Flores()
        {
            var flower = from ser in _context.Sers select ser;
            flower = flower.Where(f => f.Genero.GeneroNome.Contains("Flor"));

            return View(flower.AsEnumerable());
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
