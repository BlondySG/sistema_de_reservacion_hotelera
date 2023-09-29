using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class RegisterModel
    {
        [Display(Name = "Nombre Usuario")]
        public string UserName { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "Es obligatorio agregar el correo")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "{0} debe ser un correo válido")]
        public string Email { get; set; }

        [Required]
        [StringLength(14,ErrorMessage = "La {0} debe tener entre {2} y un maximo de {1} caracteres ", MinimumLength = 6)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
