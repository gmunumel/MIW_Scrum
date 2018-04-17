using System;
using System.Collections.Generic;

namespace RestRoomApp.Models
{
    public class Habitacion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Camas { get; set; }
        public bool EstaDisponible { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Reserva> Reservaciones { get; set; }
    }
}