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
    public class tbl_entrenamientoController : Controller
    {
        private bd_bienestarEntities db = new bd_bienestarEntities();

        // GET: tbl_entrenamiento
        public ActionResult Index()
        {
            var tbl_entrenamiento = db.tbl_entrenamiento.Include(t => t.tbl_deporte);
            return View(tbl_entrenamiento.ToList());
        }

        // GET: tbl_entrenamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_entrenamiento tbl_entrenamiento = db.tbl_entrenamiento.Find(id);
            if (tbl_entrenamiento == null)
            {
                return HttpNotFound();
            }
            return View(tbl_entrenamiento);
        }

        // GET: tbl_entrenamiento/Create
        public ActionResult Create()
        {
            ViewBag.id_deporte = new SelectList(db.tbl_deporte, "id_deporte", "nombre_deporte");
            return View();
        }

        // POST: tbl_entrenamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_entrenamiento,id_deporte,horario,lugar")] tbl_entrenamiento tbl_entrenamiento)
        {
            if (ModelState.IsValid)
            {
                db.tbl_entrenamiento.Add(tbl_entrenamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_deporte = new SelectList(db.tbl_deporte, "id_deporte", "nombre_deporte", tbl_entrenamiento.id_deporte);
            return View(tbl_entrenamiento);
        }

        // GET: tbl_entrenamiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_entrenamiento tbl_entrenamiento = db.tbl_entrenamiento.Find(id);
            if (tbl_entrenamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_deporte = new SelectList(db.tbl_deporte, "id_deporte", "nombre_deporte", tbl_entrenamiento.id_deporte);
            return View(tbl_entrenamiento);
        }

        // POST: tbl_entrenamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_entrenamiento,id_deporte,horario,lugar")] tbl_entrenamiento tbl_entrenamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_entrenamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_deporte = new SelectList(db.tbl_deporte, "id_deporte", "nombre_deporte", tbl_entrenamiento.id_deporte);
            return View(tbl_entrenamiento);
        }

        // GET: tbl_entrenamiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_entrenamiento tbl_entrenamiento = db.tbl_entrenamiento.Find(id);
            if (tbl_entrenamiento == null)
            {
                return HttpNotFound();
            }
            return View(tbl_entrenamiento);
        }

        // POST: tbl_entrenamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_entrenamiento tbl_entrenamiento = db.tbl_entrenamiento.Find(id);
            db.tbl_entrenamiento.Remove(tbl_entrenamiento);
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
