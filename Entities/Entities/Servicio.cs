using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Servicio
    {
        public Servicio()
        {
            Reservaciones = new HashSet<Reservacione>();
        }

        public int Idservicio { get; set; }
        public string NombreServicio { get; set; } = null!;
        public int CostoServicio { get; set; }

        public virtual ICollection<Reservacione> Reservaciones { get; set; }
    }
}
