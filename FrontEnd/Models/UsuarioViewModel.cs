namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {
        public int Idusuario { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public int Idrol { get; set; }
        public IEnumerable<RolViewModel> Roles { get; set; }
        public RolViewModel Rol { get; set; }
    }
}
