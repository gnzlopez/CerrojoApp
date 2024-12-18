using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CerrojoApp.DBUtils.Dtos
{
    public class ProductoDto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public long Stock { get; set; }
        public decimal Precio { get; set; }
        public long? Codigo { get; set; }
        public MarcaDto Marca { get; set; }
        public ProveedorDto Proveedor { get; set; }
    }
}
