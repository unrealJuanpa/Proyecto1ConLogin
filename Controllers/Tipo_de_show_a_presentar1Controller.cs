using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto1ConLogin.Models;

namespace Proyecto1ConLogin.Controllers
{
    public class Tipo_de_show_a_presentar1Controller : Controller
    {
        private BDEventosEntities db = new BDEventosEntities();

        // GET: Tipo_de_show_a_presentar1
        public ActionResult Index()
        {
            return View(db.Tipo_de_show_a_presentar.ToList());
        }

        // GET: Tipo_de_show_a_presentar1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_de_show_a_presentar tipo_de_show_a_presentar = db.Tipo_de_show_a_presentar.Find(id);
            if (tipo_de_show_a_presentar == null)
            {
                return HttpNotFound();
            }
            return View(tipo_de_show_a_presentar);
        }

        // GET: Tipo_de_show_a_presentar1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_de_show_a_presentar1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tipo_show,Nombre_tipo,Descripcion_tipo")] Tipo_de_show_a_presentar tipo_de_show_a_presentar)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_de_show_a_presentar.Add(tipo_de_show_a_presentar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_de_show_a_presentar);
        }

        // GET: Tipo_de_show_a_presentar1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_de_show_a_presentar tipo_de_show_a_presentar = db.Tipo_de_show_a_presentar.Find(id);
            if (tipo_de_show_a_presentar == null)
            {
                return HttpNotFound();
            }
            return View(tipo_de_show_a_presentar);
        }

        // POST: Tipo_de_show_a_presentar1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tipo_show,Nombre_tipo,Descripcion_tipo")] Tipo_de_show_a_presentar tipo_de_show_a_presentar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_de_show_a_presentar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_de_show_a_presentar);
        }

        // GET: Tipo_de_show_a_presentar1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_de_show_a_presentar tipo_de_show_a_presentar = db.Tipo_de_show_a_presentar.Find(id);
            if (tipo_de_show_a_presentar == null)
            {
                return HttpNotFound();
            }
            return View(tipo_de_show_a_presentar);
        }

        // POST: Tipo_de_show_a_presentar1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_de_show_a_presentar tipo_de_show_a_presentar = db.Tipo_de_show_a_presentar.Find(id);
            db.Tipo_de_show_a_presentar.Remove(tipo_de_show_a_presentar);
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
