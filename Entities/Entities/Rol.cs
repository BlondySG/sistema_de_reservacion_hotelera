using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Idrol { get; set; }
        public string? NombreRol { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
