using System;

namespace RestRoomApp.Models
{
    public class Reserva
    {
        public int ReservaID { get; set; }
        public int ClienteID { get; set; }
        public int HabitacionID { get; set; }
        public int HorasReservacion { get; set; }
        public int HoraInicioReservacion { get; set; }
        public DateTime FechaReservacion { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Habitacion Habitacion { get; set; }
    }
}