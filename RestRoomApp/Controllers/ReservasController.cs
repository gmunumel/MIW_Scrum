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

        private Boolean repetidaFechayhora (Reserva reserva)
        {
            var repetido = db.Reservaciones.Where( r => r.FechaReservacion == reserva.FechaReservacion && r.HoraInicioReservacion == reserva.HoraInicioReservacion);
            return (repetido.Count() != 0);
        }
        // GET: Reservas
        public ActionResult Vertodos()
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
            ViewBag.HabitacionID = new SelectList(db.Habitaciones.Where(h => h.EstaDisponible == true), "HabitacionId", "NombreCompleto");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservadto reservadto)
        {
            ViewBag.error = "";
            if (ModelState.IsValid)
            {
                var cliente = db.Clientes.Where(r => r.Correo == reservadto.Correo);
                if (cliente.Count() != 0)
                {
                    Reserva reserva = new Reserva
                    {
                        ClienteID = cliente.ToList().First().ID,
                        HabitacionID = reservadto.HabitacionID,
                        HorasReservacion = reservadto.HorasReservacion,
                        HoraInicioReservacion = reservadto.HoraInicioReservacion,
                        FechaReservacion = reservadto.FechaReservacion
                    };

                    if (!repetidaFechayhora(reserva))
                    {
                        db.Reservaciones.Add(reserva);
                        db.SaveChanges();
                        var habitacion = db.Habitaciones.Where(h => h.HabitacionId == reserva.HabitacionID);
                        habitacion.ToList().First().EstaDisponible = false;
                        db.SaveChanges();
                        return RedirectToAction("Reservascliente", new { id = reserva.ClienteID }); //return View("Reservascliente", reservaciones.ToList());
                    } else
                    {
                        ViewBag.error = "La fecha y hora reservada coincide con otra";
                    }
                } else
                {
                    ViewBag.error = "Este correo no se corresponde con ningún cliente registrado.";
                }
            }

            //ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nombre", reserva.ClienteID);
            ViewBag.HabitacionID = new SelectList(db.Habitaciones, "HabitacionId", "NombreCompleto");
            return View(reservadto);
        }

        // GET: Reservas
        public ActionResult Reservascliente (int? id)
        {
            var reservaciones = db.Reservaciones.Include(r => r.Cliente).Include(r => r.Habitacion).Where(r => r.ClienteID == id);
            return View(reservaciones.ToList());
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
            Reserva reserva = db.Reservaciones.Find(id);
            db.Reservaciones.Remove(reserva);
            db.SaveChanges();

            var reservaciones = db.Reservaciones.Include(r => r.Cliente).Include(r => r.Habitacion).Where(r => r.ClienteID == reserva.ClienteID);
            return View("Reservascliente", reservaciones.ToList());
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
