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
    public class Encargado_del_eventoController : Controller
    {
        private BDEventosEntities db = new BDEventosEntities();

        // GET: Encargado_del_evento
        public ActionResult Index()
        {
            return View(db.Encargado_del_evento.ToList());
        }

        // GET: Encargado_del_evento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encargado_del_evento encargado_del_evento = db.Encargado_del_evento.Find(id);
            if (encargado_del_evento == null)
            {
                return HttpNotFound();
            }
            return View(encargado_del_evento);
        }

        // GET: Encargado_del_evento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Encargado_del_evento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Encargado,Nombre_encargado,Telefono_contacto,Correo_electronico")] Encargado_del_evento encargado_del_evento)
        {
            if (ModelState.IsValid)
            {
                db.Encargado_del_evento.Add(encargado_del_evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(encargado_del_evento);
        }

        // GET: Encargado_del_evento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encargado_del_evento encargado_del_evento = db.Encargado_del_evento.Find(id);
            if (encargado_del_evento == null)
            {
                return HttpNotFound();
            }
            return View(encargado_del_evento);
        }

        // POST: Encargado_del_evento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Encargado,Nombre_encargado,Telefono_contacto,Correo_electronico")] Encargado_del_evento encargado_del_evento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encargado_del_evento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(encargado_del_evento);
        }

        // GET: Encargado_del_evento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encargado_del_evento encargado_del_evento = db.Encargado_del_evento.Find(id);
            if (encargado_del_evento == null)
            {
                return HttpNotFound();
            }
            return View(encargado_del_evento);
        }

        // POST: Encargado_del_evento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encargado_del_evento encargado_del_evento = db.Encargado_del_evento.Find(id);
            db.Encargado_del_evento.Remove(encargado_del_evento);
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
