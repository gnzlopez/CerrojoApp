
using Microsoft.EntityFrameworkCore;

namespace CerrojoApp.DBUtils.Dtos
{
    public class RegistroFacturaDto
    {
        public int Id { get; set; }
        public FacturaDto Factura { get; set; }
        public int RegistroNum { get; set; }
        public ProductoDto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
