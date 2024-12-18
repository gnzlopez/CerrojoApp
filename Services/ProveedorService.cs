using CerrojoApp.DBUtils;
using CerrojoApp.DBUtils.Dtos;
using CerrojoApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CerrojoApp.Services
{
    public class ProveedorService
    {
        private readonly AppDbContext _dbContext;
        public ProveedorService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SaveProveeAsync(ProveedorVM Proveedor)
        {
            ProveedorDto provee = new ProveedorDto()
            {
                Id = Proveedor.Id,
                Nombre = Proveedor.Nombre,
                Telefono = Proveedor.Telefono
            };

            if (provee.Id != null)
            {
                _dbContext.Proveedores.Update(provee);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                _dbContext.Proveedores.Add(provee);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteProveeAsync(int proveeId)
        {
            var provee = await _dbContext.Proveedores.FindAsync(proveeId);
            if (provee != null)
            {
                _dbContext.Proveedores.Remove(provee);
                await _dbContext.SaveChangesAsync();
            }
        }

        public List<ProveedorVM> GetProvees()
        {
            return _dbContext.Proveedores
                                    .Select(x => new ProveedorVM()
                                    {
                                        Id = x.Id,
                                        Nombre = x.Nombre,
                                        Telefono = x.Telefono
                                    }).ToList();
        }

        public ProveedorDto? GetProveeById(int id)
        {
            return _dbContext.Proveedores.Find(id);
        }

        public async Task<List<ProveedorVM>> GetProveesAsync()
        {
            return await _dbContext.Proveedores
                                    .Select(x => new ProveedorVM()
                                    {
                                        Id = x.Id,
                                        Nombre = x.Nombre,
                                        Telefono = x.Telefono
                                    }).ToListAsync();
        }
    }
}
