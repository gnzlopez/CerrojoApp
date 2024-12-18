using CerrojoApp.DBUtils;
using CerrojoApp.DBUtils.Dtos;
using CerrojoApp.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace CerrojoApp.Services
{
    public class MarcaService
    {
        private readonly AppDbContext _dbContext;
        public MarcaService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SaveMarcaAsync(MarcaVM Marca)
        {
            MarcaDto marca = new MarcaDto()
            {
                Id = Marca.Id,
                Nombre = Marca.Nombre,
            };

            if (marca.Id != null)
            {
                _dbContext.Marcas.Update(marca);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                _dbContext.Marcas.Add(marca);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteMarcaAsync(int marcaId)
        {
            var marca = await _dbContext.Marcas.FindAsync(marcaId);
            if (marca != null)
            {
                _dbContext.Marcas.Remove(marca);
                await _dbContext.SaveChangesAsync();
            }
        }

        public List<MarcaVM> GetMarcas()
        {
            return _dbContext.Marcas
                                    .Select(x => new MarcaVM()
                                    {
                                        Id = x.Id,
                                        Nombre = x.Nombre
                                    }).ToList();
        }

        public MarcaDto? GetMarcaById(int id)
        {
            return _dbContext.Marcas.Find(id);
        }

        public async Task<List<MarcaVM>> GetMarcasAsync()
        {
            return await _dbContext.Marcas
                                    .Select(x => new MarcaVM()
                                    {
                                        Id = x.Id,
                                        Nombre = x.Nombre
                                    }).ToListAsync();
        }
    }
}
