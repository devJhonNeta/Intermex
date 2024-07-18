using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crud;
using Crud.Views;

namespace Crud.Controllers
{
    public class RevistasController : Controller
    {
        private IntermexEntities2 db = new IntermexEntities2();

        // GET: Revistas
        public ActionResult Index()
        {
            var revistas = db.Revistas.Include(r => r.Categorias);
            return View(revistas.ToList());
        }

        // GET: Revistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revistas revistas = db.Revistas.Find(id);
            if (revistas == null)
            {
                return HttpNotFound();
            }
            return View(revistas);
        }

        // GET: Revistas/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Categorias, "Id", "Nombre");
            return View();
        }

        // POST: Revistas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Edicion,Codigo_barras,Fecha_Publicacion,Precio,Activo,Categorias_Id,Fecha_Actualizacion")] Revistas revistas)
        {
            if (ModelState.IsValid)
            {
                db.Revistas.Add(revistas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Categorias, "Id", "Nombre", revistas.Id);
            return View(revistas);
        }

        // GET: Revistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revistas revistas = db.Revistas.Find(id);
            if (revistas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Categorias, "Id", "Nombre", revistas.Id);
            return View(revistas);
        }

        // POST: Revistas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Edicion,Codigo_barras,Fecha_Publicacion,Precio,Activo,Categorias_Id,Fecha_Actualizacion")] Revistas revistas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revistas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Categorias, "Id", "Nombre", revistas.Id);
            return View(revistas);
        }

        // GET: Revistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revistas revistas = db.Revistas.Find(id);
            if (revistas == null)
            {
                return HttpNotFound();
            }
            return View(revistas);
        }

        // POST: Revistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Revistas revistas = db.Revistas.Find(id);
            db.Revistas.Remove(revistas);
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
