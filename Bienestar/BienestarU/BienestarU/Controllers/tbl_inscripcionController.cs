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
    public class tbl_inscripcionController : Controller
    {
        private bd_bienestarEntities db = new bd_bienestarEntities();

        // GET: tbl_inscripcion
        public ActionResult Index()
        {
            var tbl_inscripcion = db.tbl_inscripcion.Include(t => t.tbl_actividad_empleado).Include(t => t.tbl_categoria_usuario).Include(t => t.tbl_torneo_interno);
            return View(tbl_inscripcion.ToList());
        }

        // GET: tbl_inscripcion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_inscripcion tbl_inscripcion = db.tbl_inscripcion.Find(id);
            if (tbl_inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_inscripcion);
        }

        // GET: tbl_inscripcion/Create
        public ActionResult Create()
        {
            ViewBag.id_actividad = new SelectList(db.tbl_actividad_empleado, "id_actividad", "lugar_actividad");
            ViewBag.id_categoria_usuario = new SelectList(db.tbl_categoria_usuario, "id_categoria_usuario", "categoria_usuario");
            ViewBag.id_torneo = new SelectList(db.tbl_torneo_interno, "id_torneo", "nombre_torneo");
            return View();
        }

        // POST: tbl_inscripcion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_inscripcion,id_categoria_usuario,dni_usuario,nombres,apellidos,programa_academico,unidad_organizativa,id_actividad,id_torneo")] tbl_inscripcion tbl_inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.tbl_inscripcion.Add(tbl_inscripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_actividad = new SelectList(db.tbl_actividad_empleado, "id_actividad", "lugar_actividad", tbl_inscripcion.id_actividad);
            ViewBag.id_categoria_usuario = new SelectList(db.tbl_categoria_usuario, "id_categoria_usuario", "categoria_usuario", tbl_inscripcion.id_categoria_usuario);
            ViewBag.id_torneo = new SelectList(db.tbl_torneo_interno, "id_torneo", "nombre_torneo", tbl_inscripcion.id_torneo);
            return View(tbl_inscripcion);
        }

        // GET: tbl_inscripcion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_inscripcion tbl_inscripcion = db.tbl_inscripcion.Find(id);
            if (tbl_inscripcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_actividad = new SelectList(db.tbl_actividad_empleado, "id_actividad", "lugar_actividad", tbl_inscripcion.id_actividad);
            ViewBag.id_categoria_usuario = new SelectList(db.tbl_categoria_usuario, "id_categoria_usuario", "categoria_usuario", tbl_inscripcion.id_categoria_usuario);
            ViewBag.id_torneo = new SelectList(db.tbl_torneo_interno, "id_torneo", "nombre_torneo", tbl_inscripcion.id_torneo);
            return View(tbl_inscripcion);
        }

        // POST: tbl_inscripcion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_inscripcion,id_categoria_usuario,dni_usuario,nombres,apellidos,programa_academico,unidad_organizativa,id_actividad,id_torneo")] tbl_inscripcion tbl_inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_inscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_actividad = new SelectList(db.tbl_actividad_empleado, "id_actividad", "lugar_actividad", tbl_inscripcion.id_actividad);
            ViewBag.id_categoria_usuario = new SelectList(db.tbl_categoria_usuario, "id_categoria_usuario", "categoria_usuario", tbl_inscripcion.id_categoria_usuario);
            ViewBag.id_torneo = new SelectList(db.tbl_torneo_interno, "id_torneo", "nombre_torneo", tbl_inscripcion.id_torneo);
            return View(tbl_inscripcion);
        }

        // GET: tbl_inscripcion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_inscripcion tbl_inscripcion = db.tbl_inscripcion.Find(id);
            if (tbl_inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_inscripcion);
        }

        // POST: tbl_inscripcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_inscripcion tbl_inscripcion = db.tbl_inscripcion.Find(id);
            db.tbl_inscripcion.Remove(tbl_inscripcion);
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
