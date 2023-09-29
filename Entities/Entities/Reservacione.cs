using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Reservacione
    {
        public int Idreservacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public int CantidadNoches { get; set; }
        public string NombreCliente { get; set; } = null!;
        public int CedulaCliente { get; set; }
        public int Idhabitacion { get; set; }
        public int? Idusuario { get; set; }
        public int? Idservicio { get; set; }

        public virtual Habitacion IdhabitacionNavigation { get; set; } = null!;
        public virtual Servicio? IdservicioNavigation { get; set; }
        public virtual Usuario? IdusuarioNavigation { get; set; }
    }
}
