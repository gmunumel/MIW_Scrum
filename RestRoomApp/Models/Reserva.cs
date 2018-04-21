using System;
using System.ComponentModel.DataAnnotations;

namespace RestRoomApp.Models
{
    public class Reserva
    {
        public int ReservaID { get; set; }
        public int ClienteID { get; set; }
        public int HabitacionID { get; set; }
        public int HorasReservacion { get; set; }
        public int HoraInicioReservacion { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FechaReservacion { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Habitacion Habitacion { get; set; }
    }
}