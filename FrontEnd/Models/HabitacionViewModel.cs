using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FrontEnd.Models
{
    public class HabitacionViewModel
    {
        [Key]
        [Display(Name = "Id Room")]
        public int Idhabitacion { get; set; }

        [Display(Name = "Floor Room")]
        public string PisoHabitacion { get; set; } = null!;

        [Display(Name = "Room Type")]
        public int IdtipoHabitacion { get; set; }

        public IEnumerable<TipoHabitacionViewModel> tipoHabitaciones { get; set; }
        public TipoHabitacionViewModel TipoHabitacion { get; set; }
    }
}
