using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Reservaciones = new HashSet<Reservacione>();
        }

        public int Idusuario { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public int Idrol { get; set; }

        public virtual Rol IdrolNavigation { get; set; } = null!;
        public virtual ICollection<Reservacione> Reservaciones { get; set; }
    }
}
