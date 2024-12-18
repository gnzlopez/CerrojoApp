using CerrojoApp.DBUtils.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerrojoApp.DBUtils
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductoDto>? Productos { get; set; }
        public DbSet<MarcaDto>? Marcas { get; set; }
        public DbSet<ProveedorDto>? Proveedores { get; set; }
        public DbSet<FacturaDto>? Facturas { get; set; }
        public DbSet<RegistroFacturaDto>? RegistroFactura { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, "Productos_1.6.db");
            optionsBuilder.UseSqlite($"Data Source={path}");
        }

    }
}
