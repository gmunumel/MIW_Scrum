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
    [Authorize(Users = "admin@admin.com")]
    public class ReservasAdminController : Controller
    {
        private RestRoomAppContext db = new RestRoomAppContext();

        // GET: ReservasAdmin
        public ActionResult Index()
        {
            var reservas = db.Reservaciones.Include(r => r.Cliente).Include(r => r.Habitacion);
            return View(reservas.ToList());
        }

        // GET: ReservasAdmin/Details/5
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

        // GET: ReservasAdmin/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nombre");
            ViewBag.HabitacionID = new SelectList(db.Habitaciones, "HabitacionId", "Nombre");
            return View();
        }

        // POST: ReservasAdmin/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: ReservasAdmin/Edit/5
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

        // POST: ReservasAdmin/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: ReservasAdmin/Delete/5
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

        // POST: ReservasAdmin/Delete/5
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
