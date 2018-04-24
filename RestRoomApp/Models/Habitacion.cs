using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestRoomApp.Models
{
    public class Habitacion
    {
        public int HabitacionId { get; set; }
        public string Nombre { get; set; }
        public string Numero { get; set; }
        public string Planta { get; set; }
        public int Camas { get; set; }
        public bool EstaDisponible { get; set; }
        public string Descripcion { get; set; }
        public string Fotos { get; set; }
        public double Precio { get; set; }
        public int Categoria { get; set; }
        public string Notas { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        public virtual ICollection<Reserva> Reservaciones { get; set; }

        public string NombreCompleto
        {
            get
            {
                return $"Tipo: {Nombre}, Número de Camas: {Camas}, Precio: {Precio.ToString()} €/h, Disponibilidad {FechaCreacion}";
            }
        }
    }
}

