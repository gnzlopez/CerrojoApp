namespace CerrojoApp.DBUtils.Dtos
{
    public class ProveedorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public long? Telefono { get; set; }
        public ICollection<ProductoDto>? Productos { get; set; }
        public ICollection<MarcaDto>? Marcas{ get; set; }
    }
}
