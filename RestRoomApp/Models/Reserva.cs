using System;
using System.ComponentModel.DataAnnotations;

namespace RestRoomApp.Models
{
    public class Reserva
    {
        public int ReservaID { get; set; }
        public int ClienteID { get; set; }
        public int HabitacionID { get; set; }
        [Required(ErrorMessage = "Tiempo mínimo de alquier, 1h")]
        [Range(1,8, ErrorMessage ="Tiempo maximo de alquier, 8h")]
        public int HorasReservacion { get; set; }
        [Required(ErrorMessage = "Indica un hora de inicio")]
        [Range(0, 23, ErrorMessage = "Rango entre la 00 horas y 23 horas")]
        public int HoraInicioReservacion { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FechaReservacion { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Habitacion Habitacion { get; set; }
    }
}