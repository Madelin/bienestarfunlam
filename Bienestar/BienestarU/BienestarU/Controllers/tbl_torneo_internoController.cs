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
    public class tbl_torneo_internoController : Controller
    {
        private bd_bienestarEntities db = new bd_bienestarEntities();

        // GET: tbl_torneo_interno
        public ActionResult Index()
        {
            return View(db.tbl_torneo_interno.ToList());
        }

        // GET: tbl_torneo_interno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_torneo_interno tbl_torneo_interno = db.tbl_torneo_interno.Find(id);
            if (tbl_torneo_interno == null)
            {
                return HttpNotFound();
            }
            return View(tbl_torneo_interno);
        }

        // GET: tbl_torneo_interno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_torneo_interno/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_torneo,nombre_torneo,fecha_inicio,fecha_fin,hora")] tbl_torneo_interno tbl_torneo_interno)
        {
            if (ModelState.IsValid)
            {
                db.tbl_torneo_interno.Add(tbl_torneo_interno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_torneo_interno);
        }

        // GET: tbl_torneo_interno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_torneo_interno tbl_torneo_interno = db.tbl_torneo_interno.Find(id);
            if (tbl_torneo_interno == null)
            {
                return HttpNotFound();
            }
            return View(tbl_torneo_interno);
        }

        // POST: tbl_torneo_interno/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_torneo,nombre_torneo,fecha_inicio,fecha_fin,hora")] tbl_torneo_interno tbl_torneo_interno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_torneo_interno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_torneo_interno);
        }

        // GET: tbl_torneo_interno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_torneo_interno tbl_torneo_interno = db.tbl_torneo_interno.Find(id);
            if (tbl_torneo_interno == null)
            {
                return HttpNotFound();
            }
            return View(tbl_torneo_interno);
        }

        // POST: tbl_torneo_interno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_torneo_interno tbl_torneo_interno = db.tbl_torneo_interno.Find(id);
            db.tbl_torneo_interno.Remove(tbl_torneo_interno);
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
