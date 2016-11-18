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
    public class tbl_categoriaController : Controller
    {
        private bd_bienestarEntities db = new bd_bienestarEntities();

        // GET: tbl_categoria
        public ActionResult Index()
        {
            return View(db.tbl_categoria.ToList());
        }

        // GET: tbl_categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_categoria tbl_categoria = db.tbl_categoria.Find(id);
            if (tbl_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tbl_categoria);
        }

        // GET: tbl_categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_categoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_categoria,nombre_categoria,descripcion")] tbl_categoria tbl_categoria)
        {
            if (ModelState.IsValid)
            {
                db.tbl_categoria.Add(tbl_categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_categoria);
        }

        // GET: tbl_categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_categoria tbl_categoria = db.tbl_categoria.Find(id);
            if (tbl_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tbl_categoria);
        }

        // POST: tbl_categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_categoria,nombre_categoria,descripcion")] tbl_categoria tbl_categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_categoria);
        }

        // GET: tbl_categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_categoria tbl_categoria = db.tbl_categoria.Find(id);
            if (tbl_categoria == null)
            {
                return HttpNotFound();
            }
            return View(tbl_categoria);
        }

        // POST: tbl_categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_categoria tbl_categoria = db.tbl_categoria.Find(id);
            db.tbl_categoria.Remove(tbl_categoria);
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
