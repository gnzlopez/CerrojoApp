using System.ComponentModel.DataAnnotations;

namespace CerrojoApp.ViewModels
{
    public class ProductoVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del no puede estar vacio")]
        public string Nombre { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El producto debe tener stock (aunque sea 0)")]
        public long Stock { get; set; }
        [Range(0.01, 99999999, ErrorMessage = "El producto debe valer algo")]
        public decimal Precio { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El producto debe tener una Marca")]
        public int MarcaId { get; set; }
        public string MarcaName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El producto debe tener un Proveedor")]
        public int ProveedorId { get; set; }
        public string ProveedorName { get; set; }
    }
}
