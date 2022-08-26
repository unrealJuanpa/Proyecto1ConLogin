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
    public class Show_a_presentarController : Controller
    {
        private BDEventosEntities db = new BDEventosEntities();

        // GET: Show_a_presentar
        public ActionResult Index()
        {
            var show_a_presentar = db.Show_a_presentar.Include(s => s.Tipo_de_show_a_presentar);
            return View(show_a_presentar.ToList());
        }

        // GET: Show_a_presentar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show_a_presentar show_a_presentar = db.Show_a_presentar.Find(id);
            if (show_a_presentar == null)
            {
                return HttpNotFound();
            }
            return View(show_a_presentar);
        }

        // GET: Show_a_presentar/Create
        public ActionResult Create()
        {
            ViewBag.Tipo_show = new SelectList(db.Tipo_de_show_a_presentar, "Tipo_show", "Nombre_tipo");
            return View();
        }

        // POST: Show_a_presentar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Show,Nombre_show,Descripcion,Costo_por_hora,Tipo_show")] Show_a_presentar show_a_presentar)
        {
            if (ModelState.IsValid)
            {
                db.Show_a_presentar.Add(show_a_presentar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Tipo_show = new SelectList(db.Tipo_de_show_a_presentar, "Tipo_show", "Nombre_tipo", show_a_presentar.Tipo_show);
            return View(show_a_presentar);
        }

        // GET: Show_a_presentar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show_a_presentar show_a_presentar = db.Show_a_presentar.Find(id);
            if (show_a_presentar == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tipo_show = new SelectList(db.Tipo_de_show_a_presentar, "Tipo_show", "Nombre_tipo", show_a_presentar.Tipo_show);
            return View(show_a_presentar);
        }

        // POST: Show_a_presentar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Show,Nombre_show,Descripcion,Costo_por_hora,Tipo_show")] Show_a_presentar show_a_presentar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show_a_presentar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Tipo_show = new SelectList(db.Tipo_de_show_a_presentar, "Tipo_show", "Nombre_tipo", show_a_presentar.Tipo_show);
            return View(show_a_presentar);
        }

        // GET: Show_a_presentar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show_a_presentar show_a_presentar = db.Show_a_presentar.Find(id);
            if (show_a_presentar == null)
            {
                return HttpNotFound();
            }
            return View(show_a_presentar);
        }

        // POST: Show_a_presentar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Show_a_presentar show_a_presentar = db.Show_a_presentar.Find(id);
            db.Show_a_presentar.Remove(show_a_presentar);
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
