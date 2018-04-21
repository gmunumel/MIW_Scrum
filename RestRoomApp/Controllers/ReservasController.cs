using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestRoomApp.DAL;
using RestRoomApp.Models;

namespace RestRoomApp.Controllers
{
    public class ReservasController : Controller
    {
        private RestRoomAppContext db = new RestRoomAppContext();

        // GET: Reservas
        public ActionResult Index()
        {
            var reservaciones = db.Reservaciones.Include(r => r.Cliente).Include(r => r.Habitacion);
            return View(reservaciones.ToList());
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservaciones.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nombre");
            ViewBag.HabitacionID = new SelectList(db.Habitaciones, "HabitacionId", "Nombre");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservaID,ClienteID,HabitacionID,HorasReservacion,HoraInicioReservacion,FechaReservacion")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Reservaciones.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nombre", reserva.ClienteID);
            ViewBag.HabitacionID = new SelectList(db.Habitaciones, "HabitacionId", "Nombre", reserva.HabitacionID);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservaciones.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nombre", reserva.ClienteID);
            ViewBag.HabitacionID = new SelectList(db.Habitaciones, "HabitacionId", "Nombre", reserva.HabitacionID);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservaID,ClienteID,HabitacionID,HorasReservacion,HoraInicioReservacion,FechaReservacion")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nombre", reserva.ClienteID);
            ViewBag.HabitacionID = new SelectList(db.Habitaciones, "HabitacionId", "Nombre", reserva.HabitacionID);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservaciones.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserva reserva = db.Reservaciones.Find(id);
            db.Reservaciones.Remove(reserva);
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
