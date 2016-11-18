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
    public class responsable_categoriaController : Controller
    {
        private bd_bienestarEntities db = new bd_bienestarEntities();

        // GET: responsable_categoria
        public ActionResult Index()
        {
            var responsable_categoria = db.responsable_categoria.Include(r => r.tbl_categoria).Include(r => r.tbl_grupo);
            return View(responsable_categoria.ToList());
        }

        // GET: responsable_categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            responsable_categoria responsable_categoria = db.responsable_categoria.Find(id);
            if (responsable_categoria == null)
            {
                return HttpNotFound();
            }
            return View(responsable_categoria);
        }

        // GET: responsable_categoria/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.tbl_categoria, "id_categoria", "nombre_categoria");
            ViewBag.id_grupo = new SelectList(db.tbl_grupo, "id_grupo", "descripcion");
            return View();
        }

        // POST: responsable_categoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_responsable,nombre_responsable,correo_responsable,tel_responsable,coordinador,tel_coordinador,correo_coordinador,id_grupo,id_categoria")] responsable_categoria responsable_categoria)
        {
            if (ModelState.IsValid)
            {
                db.responsable_categoria.Add(responsable_categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.tbl_categoria, "id_categoria", "nombre_categoria", responsable_categoria.id_categoria);
            ViewBag.id_grupo = new SelectList(db.tbl_grupo, "id_grupo", "descripcion", responsable_categoria.id_grupo);
            return View(responsable_categoria);
        }

        // GET: responsable_categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            responsable_categoria responsable_categoria = db.responsable_categoria.Find(id);
            if (responsable_categoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.tbl_categoria, "id_categoria", "nombre_categoria", responsable_categoria.id_categoria);
            ViewBag.id_grupo = new SelectList(db.tbl_grupo, "id_grupo", "descripcion", responsable_categoria.id_grupo);
            return View(responsable_categoria);
        }

        // POST: responsable_categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_responsable,nombre_responsable,correo_responsable,tel_responsable,coordinador,tel_coordinador,correo_coordinador,id_grupo,id_categoria")] responsable_categoria responsable_categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsable_categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.tbl_categoria, "id_categoria", "nombre_categoria", responsable_categoria.id_categoria);
            ViewBag.id_grupo = new SelectList(db.tbl_grupo, "id_grupo", "descripcion", responsable_categoria.id_grupo);
            return View(responsable_categoria);
        }

        // GET: responsable_categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            responsable_categoria responsable_categoria = db.responsable_categoria.Find(id);
            if (responsable_categoria == null)
            {
                return HttpNotFound();
            }
            return View(responsable_categoria);
        }

        // POST: responsable_categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            responsable_categoria responsable_categoria = db.responsable_categoria.Find(id);
            db.responsable_categoria.Remove(responsable_categoria);
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
