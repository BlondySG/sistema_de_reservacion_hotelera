using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Habitacion
    {
        public Habitacion()
        {
            Reservaciones = new HashSet<Reservacione>();
        }

        public int Idhabitacion { get; set; }
        public string PisoHabitacion { get; set; } = null!;
        public int IdtipoHabitacion { get; set; }

        public virtual TipoHabitacion IdtipoHabitacionNavigation { get; set; } = null!;
        public virtual ICollection<Reservacione> Reservaciones { get; set; }
    }
}
