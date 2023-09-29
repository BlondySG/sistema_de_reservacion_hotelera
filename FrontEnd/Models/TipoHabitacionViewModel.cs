using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class TipoHabitacionViewModel
    {
        [Key]
        [Display(Name = "ID")]
        public int IdtipoHabitacion { get; set; }

        [Required(ErrorMessage = "Es obligatorio indicar el tipo de habitación")]
        [Display(Name = "Tipo Habitación")]

        public string NombreTipoHabitacion { get; set; } = null!;

        [Required(ErrorMessage = "Es obligatorio agregar el precio")]
        [Display(Name = "Costo")]
        [Range(0.01, 10000000, ErrorMessage = "El precio debe ser mayor a cero")]
        public int CostoTipoHabitacion { get; set; }
    }
}
