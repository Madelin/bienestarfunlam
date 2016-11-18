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
    public class tbl_categoria_culturaController : Controller
    {
        private bd_bienestarEntities db = new bd_bienestarEntities();

        // GET: tbl_categoria_cultura
        public ActionResult Index()
        {
            var tbl_categoria_cultura = db.tbl_categoria_cultura.Include(t => t.tbl_categoria_usuario).Include(t => t.tbl_horario).Include(t => t.tbl_titulo_cultural);
            return View(tbl_categoria_cultura.ToList());
        }

        // GET: tbl_categoria_cultura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_categoria_cultura tbl_categoria_cultura = db.tbl_categoria_cultura.Find(id);
            if (tbl_categoria_cultura == null)
            {
                return HttpNotFound();
            }
            return View(tbl_categoria_cultura);
        }

        // GET: tbl_categoria_cultura/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria_usuario = new SelectList(db.tbl_categoria_usuario, "id_categoria_usuario", "categoria_usuario");
            ViewBag.id_horario = new SelectList(db.tbl_horario, "id_horario", "dia");
            ViewBag.id_titulo = new SelectList(db.tbl_titulo_cultural, "id_titulo", "nombre_titulo");
            return View();
        }

        // POST: tbl_categoria_cultura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_categoria_cultura,id_titulo,id_horario,id_categoria_usuario,valor,descripcion")] tbl_categoria_cultura tbl_categoria_cultura)
        {
            if (ModelState.IsValid)
            {
                db.tbl_categoria_cultura.Add(tbl_categoria_cultura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria_usuario = new SelectList(db.tbl_categoria_usuario, "id_categoria_usuario", "categoria_usuario", tbl_categoria_cultura.id_categoria_usuario);
            ViewBag.id_horario = new SelectList(db.tbl_horario, "id_horario", "dia", tbl_categoria_cultura.id_horario);
            ViewBag.id_titulo = new SelectList(db.tbl_titulo_cultural, "id_titulo", "nombre_titulo", tbl_categoria_cultura.id_titulo);
            return View(tbl_categoria_cultura);
        }

        // GET: tbl_categoria_cultura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_categoria_cultura tbl_categoria_cultura = db.tbl_categoria_cultura.Find(id);
            if (tbl_categoria_cultura == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria_usuario = new SelectList(db.tbl_categoria_usuario, "id_categoria_usuario", "categoria_usuario", tbl_categoria_cultura.id_categoria_usuario);
            ViewBag.id_horario = new SelectList(db.tbl_horario, "id_horario", "dia", tbl_categoria_cultura.id_horario);
            ViewBag.id_titulo = new SelectList(db.tbl_titulo_cultural, "id_titulo", "nombre_titulo", tbl_categoria_cultura.id_titulo);
            return View(tbl_categoria_cultura);
        }

        // POST: tbl_categoria_cultura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_categoria_cultura,id_titulo,id_horario,id_categoria_usuario,valor,descripcion")] tbl_categoria_cultura tbl_categoria_cultura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_categoria_cultura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria_usuario = new SelectList(db.tbl_categoria_usuario, "id_categoria_usuario", "categoria_usuario", tbl_categoria_cultura.id_categoria_usuario);
            ViewBag.id_horario = new SelectList(db.tbl_horario, "id_horario", "dia", tbl_categoria_cultura.id_horario);
            ViewBag.id_titulo = new SelectList(db.tbl_titulo_cultural, "id_titulo", "nombre_titulo", tbl_categoria_cultura.id_titulo);
            return View(tbl_categoria_cultura);
        }

        // GET: tbl_categoria_cultura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_categoria_cultura tbl_categoria_cultura = db.tbl_categoria_cultura.Find(id);
            if (tbl_categoria_cultura == null)
            {
                return HttpNotFound();
            }
            return View(tbl_categoria_cultura);
        }

        // POST: tbl_categoria_cultura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_categoria_cultura tbl_categoria_cultura = db.tbl_categoria_cultura.Find(id);
            db.tbl_categoria_cultura.Remove(tbl_categoria_cultura);
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
