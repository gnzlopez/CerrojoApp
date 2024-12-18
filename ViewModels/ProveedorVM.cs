using System.ComponentModel.DataAnnotations;

namespace CerrojoApp.ViewModels
{
    public class ProveedorVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del no puede estar vacio")]
        public string Nombre { get; set; }
        public long? Telefono { get; set; }
    }
}
