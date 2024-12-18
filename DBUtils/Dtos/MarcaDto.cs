
namespace CerrojoApp.DBUtils.Dtos
{
    public class MarcaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<ProveedorDto>? Proveedores { get; set; } 
    }
}
