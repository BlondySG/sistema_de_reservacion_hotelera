namespace Backend.Models
{
    public class ReservacionesModel
    {
        public int Idreservacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public int CantidadNoches { get; set; }
        public string NombreCliente { get; set; } = null!;
        public int CedulaCliente { get; set; }
        public int Idhabitacion { get; set; }
        public int? Idusuario { get; set; }

        public int? Idservicio { get; set; }
    }
}
