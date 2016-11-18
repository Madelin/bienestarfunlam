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
    public class tbl_asignacion_lockerController : Controller
    {
        private bd_bienestarEntities db = new bd_bienestarEntities();

        // GET: tbl_asignacion_locker
        public ActionResult Index()
        {
            var tbl_asignacion_locker = db.tbl_asignacion_locker.Include(t => t.tbl_categoria_usuario).Include(t => t.tbl_locker);
            return View(tbl_asignacion_locker.ToList());
        }

        // GET: tbl_asignacion_locker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_asignacion_locker tbl_asignacion_locker = db.tbl_asignacion_locker.Find(id);
            if (tbl_asignacion_locker == null)
            {
                return HttpNotFound();
            }
            return View(tbl_asignacion_locker);
        }

        // GET: tbl_asignacion_locker/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria_usuario = new SelectList(db.tbl_categoria_usuario, "id_categoria_usuario", "categoria_usuario");
            ViewBag.id_locker = new SelectList(db.tbl_locker, "id_locker", "numero");
            return View();
        }

        // POST: tbl_asignacion_locker/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_asignacion,id_locker,id_categoria_usuario,dni_usuario,Nombre_usuario,Apellidos_usuario")] tbl_asignacion_locker tbl_asignacion_locker)
        {
            if (ModelState.IsValid)
            {
                db.tbl_asignacion_locker.Add(tbl_asignacion_locker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria_usuario = new SelectList(db.tbl_categoria_usuario, "id_categoria_usuario", "categoria_usuario", tbl_asignacion_locker.id_categoria_usuario);
            ViewBag.id_locker = new SelectList(db.tbl_locker, "id_locker", "numero", tbl_asignacion_locker.id_locker);
            return View(tbl_asignacion_locker);
        }

        // GET: tbl_asignacion_locker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_asignacion_locker tbl_asignacion_locker = db.tbl_asignacion_locker.Find(id);
            if (tbl_asignacion_locker == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria_usuario = new SelectList(db.tbl_categoria_usuario, "id_categoria_usuario", "categoria_usuario", tbl_asignacion_locker.id_categoria_usuario);
            ViewBag.id_locker = new SelectList(db.tbl_locker, "id_locker", "numero", tbl_asignacion_locker.id_locker);
            return View(tbl_asignacion_locker);
        }

        // POST: tbl_asignacion_locker/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_asignacion,id_locker,id_categoria_usuario,dni_usuario,Nombre_usuario,Apellidos_usuario")] tbl_asignacion_locker tbl_asignacion_locker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_asignacion_locker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria_usuario = new SelectList(db.tbl_categoria_usuario, "id_categoria_usuario", "categoria_usuario", tbl_asignacion_locker.id_categoria_usuario);
            ViewBag.id_locker = new SelectList(db.tbl_locker, "id_locker", "numero", tbl_asignacion_locker.id_locker);
            return View(tbl_asignacion_locker);
        }

        // GET: tbl_asignacion_locker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_asignacion_locker tbl_asignacion_locker = db.tbl_asignacion_locker.Find(id);
            if (tbl_asignacion_locker == null)
            {
                return HttpNotFound();
            }
            return View(tbl_asignacion_locker);
        }

        // POST: tbl_asignacion_locker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_asignacion_locker tbl_asignacion_locker = db.tbl_asignacion_locker.Find(id);
            db.tbl_asignacion_locker.Remove(tbl_asignacion_locker);
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
