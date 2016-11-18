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
    public class tbl_actividad_gimnasioController : Controller
    {
        private bd_bienestarEntities db = new bd_bienestarEntities();

        // GET: tbl_actividad_gimnasio
        public ActionResult Index()
        {
            return View(db.tbl_actividad_gimnasio.ToList());
        }

        // GET: tbl_actividad_gimnasio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_actividad_gimnasio tbl_actividad_gimnasio = db.tbl_actividad_gimnasio.Find(id);
            if (tbl_actividad_gimnasio == null)
            {
                return HttpNotFound();
            }
            return View(tbl_actividad_gimnasio);
        }

        // GET: tbl_actividad_gimnasio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_actividad_gimnasio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_actividad_gym,nombre_actividad_gym,horario,lugar")] tbl_actividad_gimnasio tbl_actividad_gimnasio)
        {
            if (ModelState.IsValid)
            {
                db.tbl_actividad_gimnasio.Add(tbl_actividad_gimnasio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_actividad_gimnasio);
        }

        // GET: tbl_actividad_gimnasio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_actividad_gimnasio tbl_actividad_gimnasio = db.tbl_actividad_gimnasio.Find(id);
            if (tbl_actividad_gimnasio == null)
            {
                return HttpNotFound();
            }
            return View(tbl_actividad_gimnasio);
        }

        // POST: tbl_actividad_gimnasio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_actividad_gym,nombre_actividad_gym,horario,lugar")] tbl_actividad_gimnasio tbl_actividad_gimnasio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_actividad_gimnasio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_actividad_gimnasio);
        }

        // GET: tbl_actividad_gimnasio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_actividad_gimnasio tbl_actividad_gimnasio = db.tbl_actividad_gimnasio.Find(id);
            if (tbl_actividad_gimnasio == null)
            {
                return HttpNotFound();
            }
            return View(tbl_actividad_gimnasio);
        }

        // POST: tbl_actividad_gimnasio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_actividad_gimnasio tbl_actividad_gimnasio = db.tbl_actividad_gimnasio.Find(id);
            db.tbl_actividad_gimnasio.Remove(tbl_actividad_gimnasio);
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
