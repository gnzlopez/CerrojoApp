using System.ComponentModel.DataAnnotations;

namespace CerrojoApp.ViewModels
{
    public class MarcaVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del no puede estar vacio")]
        public string Nombre { get; set; }
        public ICollection<int>? ProveedoresId { get; set; }
    }
}
