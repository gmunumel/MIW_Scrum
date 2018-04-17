using System;
using System.Collections.Generic;

namespace RestRoomApp.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set;  }
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Reserva> Reservaciones { get; set; }
    }
}