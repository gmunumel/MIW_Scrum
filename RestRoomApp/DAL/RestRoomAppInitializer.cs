using RestRoomApp.Models;
using System;
using System.Collections.Generic;

namespace RestRoomApp.DAL
{
    public class RestRoomAppInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RestRoomAppContext>
    {
        protected override void Seed(RestRoomAppContext context)
        {
            var clientes = new List<Cliente>
            {
                new Cliente{Nombre="Carson",Apellido="Alexander",Correo="calexander@gmail.com",FechaCreacion=DateTime.Parse("2018-09-01")},
                new Cliente{Nombre="Arturo",Apellido="Anand",Correo="aanand@gmail.com",FechaCreacion=DateTime.Parse("2018-10-01")},
                new Cliente{Nombre="Laura",Apellido="Norman",Correo="lnorman@gmail.com",FechaCreacion=DateTime.Parse("2018-11-01")}
            };

            clientes.ForEach(s => context.Clientes.Add(s));
            context.SaveChanges();

            var habitaciones = new List<Habitacion>
            {
                new Habitacion{Nombre="Suite",Camas=2,EstaDisponible=true,FechaCreacion=DateTime.Parse("2018-11-01"), Precio=20},
                new Habitacion{Nombre="Simple",Camas=1,EstaDisponible=true,FechaCreacion=DateTime.Parse("2018-11-01"), Precio=20},
                new Habitacion{Nombre="Suite Presidencial",Camas=3,EstaDisponible=true,FechaCreacion=DateTime.Parse("2018-11-01"), Precio=100}
            };

            habitaciones.ForEach(s => context.Habitaciones.Add(s));
            context.SaveChanges();

            var reservas = new List<Reserva>
            {
                new Reserva{ClienteID=1,HabitacionID=1,HorasReservacion=2,HoraInicioReservacion=14,FechaReservacion=DateTime.Parse("2018-11-01")},
                new Reserva{ClienteID=2,HabitacionID=2,HorasReservacion=2,HoraInicioReservacion=15,FechaReservacion=DateTime.Parse("2018-11-01")},
                new Reserva{ClienteID=3,HabitacionID=3,HorasReservacion=2,HoraInicioReservacion=16,FechaReservacion=DateTime.Parse("2018-11-01")}
            };
            reservas.ForEach(s => context.Reservaciones.Add(s));
            context.SaveChanges();

            var administradores = new List<Administrador>
            {
                new Administrador{Nombre="admin",Apellido="first",Correo="firstadmin@gmail.com"},
            };
            administradores.ForEach(s => context.Administradors.Add(s));
            context.SaveChanges();
        }
    }
}