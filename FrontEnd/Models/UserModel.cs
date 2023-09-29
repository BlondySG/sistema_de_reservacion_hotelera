using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class UserModel
    {
        [Display(Name = "Nombre Usuario")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string UserName { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "{0} es requerida")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
