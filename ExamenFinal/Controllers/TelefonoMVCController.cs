using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ExamenFinal.Models;

namespace ExamenFinal.Controllers
{
    public class TelefonoMVCController : Controller
    {
        private CellphoneEntities db = new CellphoneEntities();

        // GET: TelefonoMVC
        public ActionResult Index()
        {
            IEnumerable<Telefono> alumno = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50529/api/");
                //GET ALUMNOS
                //obtiene asincronamente y espera hasta obetener la data
                var responseTask = client.GetAsync("telefono");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var leer = result.Content.ReadAsAsync<IList<Telefono>>();
                    leer.Wait();
                    alumno = leer.Result;
                }
                else
                {
                    alumno = Enumerable.Empty<Telefono>();
                    ModelState.AddModelError(string.Empty, "Error .... Try Again");
                }
            }
            return View(alumno.ToList());
        }
        // GET: TelefonoMVC/Detalles
        public ActionResult Detalles()
        {
            IEnumerable<Telefono> alumno = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50529/api/");
                //GET ALUMNOS
                //obtiene asincronamente y espera hasta obetener la data
                var responseTask = client.GetAsync("telefono");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var leer = result.Content.ReadAsAsync<IList<Telefono>>();
                    leer.Wait();
                    alumno = leer.Result;
                }
                else
                {
                    alumno = Enumerable.Empty<Telefono>();
                    ModelState.AddModelError(string.Empty, "Error .... Try Again");
                }
            }
            return View(alumno.ToList());
        }

        // GET: TelefonoMVC/Details/5
        public ActionResult Details(int? id)
        {
            Telefono alumno = new Telefono();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50529/api/");
                //GET GetAlumnos

                //Obtiene asincronamente y espera hasta obtenet la data

                var responseTask = client.GetAsync("telefono/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //leer todo el contenido y parsearlo a lista Alumno
                    var leer = result.Content.ReadAsAsync<Telefono>();
                    alumno = leer.Result;
                }
                else
                {
                    alumno = null;
                    ModelState.AddModelError(string.Empty, "Error....");
                }
            }

            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // GET: TelefonoMVC/Create
        public ActionResult Create()
        {
            ViewBag.id_color = new SelectList(db.Color, "id_color", "colorcell");
            ViewBag.id_ensamble = new SelectList(db.Ensamble, "id_ensamble", "pais");
            ViewBag.id_gama = new SelectList(db.Gama, "id_gama", "gamacell");
            return View();

        }
        
        //return View();
        // POST: TelefonoMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_telefono,marca,precio,id_gama,id_ensamble,id_color")] Telefono telefono)
        {
            
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:50529/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("telefono", telefono);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ModelState.AddModelError(string.Empty, "Error en la insercion, favor contacte al administrador");
            }
            return RedirectToAction("Index");
        }

        // GET: TelefonoMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Telefono telefono = db.Telefono.Find(id);
            //if (telefono == null)
            //{
            //    return HttpNotFound();
            //}
            
            //ViewBag.id_ensamble = new SelectList(db.Ensamble, "id_ensamble", "pais", telefono.id_ensamble);
            //ViewBag.id_gama = new SelectList(db.Gama, "id_gama", "gamacell", telefono.id_gama);
            //return View(telefono);

            Telefono alumno = new Telefono();

            ViewBag.id_color = new SelectList(db.Color, "id_color", "colorcell", alumno.id_color);
            ViewBag.id_ensamble = new SelectList(db.Ensamble, "id_ensamble", "pais", alumno.id_ensamble);
            ViewBag.id_gama = new SelectList(db.Gama, "id_gama", "gamacell", alumno.id_gama);
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50529/api/");
                //GET GetAlumnos

                //Obtiene asincronamente y espera hasta obtenet la data

                var responseTask = client.GetAsync("telefono/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //leer todo el contenido y parsearlo a lista Alumno
                    var leer = result.Content.ReadAsAsync<Telefono>();
                    alumno = leer.Result;
                }
                else
                {
                    alumno = null;
                    ModelState.AddModelError(string.Empty, "Error....");
                }
            }

            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: TelefonoMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_telefono,marca,precio,id_gama,id_ensamble,id_color")] Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_color = new SelectList(db.Color, "id_color", "colorcell", telefono.id_color);
            ViewBag.id_ensamble = new SelectList(db.Ensamble, "id_ensamble", "pais", telefono.id_ensamble);
            ViewBag.id_gama = new SelectList(db.Gama, "id_gama", "gamacell", telefono.id_gama);
            return View(telefono);
        }

        // GET: TelefonoMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefono telefono = db.Telefono.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        // POST: TelefonoMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefono telefono = db.Telefono.Find(id);
            db.Telefono.Remove(telefono);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
