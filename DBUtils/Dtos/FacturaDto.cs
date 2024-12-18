
namespace CerrojoApp.DBUtils.Dtos
{
    public class FacturaDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public List<RegistroFacturaDto>? Registros { get; set; }
        public decimal MontoTotal {  get; set; }
        public DateTime Fecha { get; set; }

    }
}
