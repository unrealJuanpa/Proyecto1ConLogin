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
    public class Alquiler_de_espacioController : Controller
    {
        private BDEventosEntities db = new BDEventosEntities();

        // GET: Alquiler_de_espacio
        public ActionResult Index()
        {
            var alquiler_de_espacio = db.Alquiler_de_espacio.Include(a => a.Encargado_del_evento).Include(a => a.Show_a_presentar);
            return View(alquiler_de_espacio.ToList());
        }

        // GET: Alquiler_de_espacio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alquiler_de_espacio alquiler_de_espacio = db.Alquiler_de_espacio.Find(id);
            if (alquiler_de_espacio == null)
            {
                return HttpNotFound();
            }
            return View(alquiler_de_espacio);
        }

        // GET: Alquiler_de_espacio/Create
        public ActionResult Create()
        {
            ViewBag.Encargado = new SelectList(db.Encargado_del_evento, "Encargado", "Nombre_encargado");
            ViewBag.Show = new SelectList(db.Show_a_presentar, "Show", "Nombre_show");
            return View();
        }

        // POST: Alquiler_de_espacio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Alquiler_evento,Nombre_del_evento,Cantidad_de_asistentes,Fecha_del_evento,Hora_del_evento,Encargado,Show")] Alquiler_de_espacio alquiler_de_espacio)
        {
            if (ModelState.IsValid)
            {
                db.Alquiler_de_espacio.Add(alquiler_de_espacio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Encargado = new SelectList(db.Encargado_del_evento, "Encargado", "Nombre_encargado", alquiler_de_espacio.Encargado);
            ViewBag.Show = new SelectList(db.Show_a_presentar, "Show", "Nombre_show", alquiler_de_espacio.Show);
            return View(alquiler_de_espacio);
        }

        // GET: Alquiler_de_espacio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alquiler_de_espacio alquiler_de_espacio = db.Alquiler_de_espacio.Find(id);
            if (alquiler_de_espacio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Encargado = new SelectList(db.Encargado_del_evento, "Encargado", "Nombre_encargado", alquiler_de_espacio.Encargado);
            ViewBag.Show = new SelectList(db.Show_a_presentar, "Show", "Nombre_show", alquiler_de_espacio.Show);
            return View(alquiler_de_espacio);
        }

        // POST: Alquiler_de_espacio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Alquiler_evento,Nombre_del_evento,Cantidad_de_asistentes,Fecha_del_evento,Hora_del_evento,Encargado,Show")] Alquiler_de_espacio alquiler_de_espacio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alquiler_de_espacio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Encargado = new SelectList(db.Encargado_del_evento, "Encargado", "Nombre_encargado", alquiler_de_espacio.Encargado);
            ViewBag.Show = new SelectList(db.Show_a_presentar, "Show", "Nombre_show", alquiler_de_espacio.Show);
            return View(alquiler_de_espacio);
        }

        // GET: Alquiler_de_espacio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alquiler_de_espacio alquiler_de_espacio = db.Alquiler_de_espacio.Find(id);
            if (alquiler_de_espacio == null)
            {
                return HttpNotFound();
            }
            return View(alquiler_de_espacio);
        }

        // POST: Alquiler_de_espacio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alquiler_de_espacio alquiler_de_espacio = db.Alquiler_de_espacio.Find(id);
            db.Alquiler_de_espacio.Remove(alquiler_de_espacio);
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
