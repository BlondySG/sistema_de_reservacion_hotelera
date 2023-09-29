namespace FrontEnd.Models
{
    public class ReservacionesViewModel
    {
        public int Idreservacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public int CantidadNoches { get; set; }
        public string NombreCliente { get; set; } = null!;
        public int CedulaCliente { get; set; }
        public int Idhabitacion { get; set; }
        public IEnumerable<HabitacionViewModel> Habitaciones { get; set; } = null!;
        public HabitacionViewModel Habitacion { get; set; } = null!;
        public int Idusuario { get; set; }
        public IEnumerable<UsuarioViewModel> Usuarios { get; set; } = null!;
        public UsuarioViewModel Usuario { get; set; } = null!;
    }
}

