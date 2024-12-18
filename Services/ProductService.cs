using CerrojoApp.DBUtils;
using CerrojoApp.DBUtils.Dtos;
using CerrojoApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CerrojoApp.Services
{
    public class ProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private static ProductoVM MapperOut(ProductoDto prod)
        {
            return new ProductoVM()
            {
                Id = prod.Id,
                Nombre = prod.Nombre,
                Stock = prod.Stock,
                Precio = prod.Precio,
                MarcaId = prod.Marca != null ? prod.Marca.Id : 0,
                MarcaName = prod.Marca != null ? prod.Marca.Nombre : "",
                ProveedorId = prod.Proveedor != null ? prod.Proveedor.Id : 0,
                ProveedorName = prod.Proveedor != null ? prod.Proveedor.Nombre : ""
            };
        }

        public async Task SaveProductAsync(ProductoVM product)
        {
            if (product.Id > 0)
            {
                var prodToUpd = _dbContext.Productos.Find(product.Id);
                if (prodToUpd != null)
                {
                    prodToUpd.Nombre = product.Nombre;
                    prodToUpd.Stock = product.Stock;
                    prodToUpd.Precio = product.Precio;
                    prodToUpd.Marca = _dbContext.Marcas.Find(product.MarcaId);
                    prodToUpd.Proveedor = _dbContext.Proveedores.Find(product.ProveedorId);
                }
            }
            else
            {
                var prod = new ProductoDto()
                {
                    Id = product.Id,
                    Nombre = product.Nombre,
                    Stock = product.Stock,
                    Precio = product.Precio,
                    Marca = _dbContext.Marcas.Find(product.MarcaId),
                    Proveedor = _dbContext.Proveedores.Find(product.ProveedorId)
                };

                _dbContext.Productos.Add(prod);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var prod = await _dbContext.Productos.FindAsync(productId);
            if (prod != null) 
            {
                _dbContext.Productos.Remove(prod);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<ProductoVM>> GetProductsAsync()
        {
            return await _dbContext.Productos.Include(x => x.Marca)
                                            .AsNoTracking()
                                            .Include(x => x.Proveedor)
                                            .AsNoTracking()
                                            .Select(x => MapperOut(x))
                                            .ToListAsync();
        }

        public async Task<ProductoVM> GetProductByIdAsync(int productId)
        {
            var result = await _dbContext.Productos.FindAsync(productId);
            if (result != null)
                return MapperOut(result);
            else
                throw new Exception();
        }

        public async Task<List<ProductoVM>> SearchProductsAsync(string name)
        {
            return await _dbContext.Productos.Include(x => x.Marca)
                                            .AsNoTracking()
                                            .Include(x => x.Proveedor)
                                            .AsNoTracking()
                                            .Where(x => x.Nombre == name)
                                            .Select(x => MapperOut(x))
                                            .ToListAsync();
        }
    }
}
