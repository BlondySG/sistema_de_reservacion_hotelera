using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class TipoHabitacion
    {
        public TipoHabitacion()
        {
            Habitacions = new HashSet<Habitacion>();
        }

        public int IdtipoHabitacion { get; set; }
        public string NombreTipoHabitacion { get; set; } = null!;
        public int CostoTipoHabitacion { get; set; }

        public virtual ICollection<Habitacion> Habitacions { get; set; }
    }
}
