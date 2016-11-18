using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BienestarU.Models;

namespace BienestarU.Controllers
{
    public class tbl_deporteController : Controller
    {
        private bd_bienestarEntities db = new bd_bienestarEntities();

        // GET: tbl_deporte
        public ActionResult Index()
        {
            var tbl_deporte = db.tbl_deporte.Include(t => t.tbl_entrenador);
            return View(tbl_deporte.ToList());
        }

        // GET: tbl_deporte/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_deporte tbl_deporte = db.tbl_deporte.Find(id);
            if (tbl_deporte == null)
            {
                return HttpNotFound();
            }
            return View(tbl_deporte);
        }

        // GET: tbl_deporte/Create
        public ActionResult Create()
        {
            ViewBag.dni_entrenador = new SelectList(db.tbl_entrenador, "dni_entrenador", "nombre_entrenador");
            return View();
        }

        // POST: tbl_deporte/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_deporte,nombre_deporte,valor,dni_entrenador")] tbl_deporte tbl_deporte)
        {
            if (ModelState.IsValid)
            {
                db.tbl_deporte.Add(tbl_deporte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dni_entrenador = new SelectList(db.tbl_entrenador, "dni_entrenador", "nombre_entrenador", tbl_deporte.dni_entrenador);
            return View(tbl_deporte);
        }

        // GET: tbl_deporte/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_deporte tbl_deporte = db.tbl_deporte.Find(id);
            if (tbl_deporte == null)
            {
                return HttpNotFound();
            }
            ViewBag.dni_entrenador = new SelectList(db.tbl_entrenador, "dni_entrenador", "nombre_entrenador", tbl_deporte.dni_entrenador);
            return View(tbl_deporte);
        }

        // POST: tbl_deporte/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_deporte,nombre_deporte,valor,dni_entrenador")] tbl_deporte tbl_deporte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_deporte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dni_entrenador = new SelectList(db.tbl_entrenador, "dni_entrenador", "nombre_entrenador", tbl_deporte.dni_entrenador);
            return View(tbl_deporte);
        }

        // GET: tbl_deporte/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_deporte tbl_deporte = db.tbl_deporte.Find(id);
            if (tbl_deporte == null)
            {
                return HttpNotFound();
            }
            return View(tbl_deporte);
        }

        // POST: tbl_deporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_deporte tbl_deporte = db.tbl_deporte.Find(id);
            db.tbl_deporte.Remove(tbl_deporte);
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
