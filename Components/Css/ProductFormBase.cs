using CerrojoApp.ViewModels;
using CerrojoApp.Services;
using Microsoft.AspNetCore.Components;

namespace CerrojoApp.Components.Css
{
    public class ProductFormBase : ComponentBase
    {
        [Inject]
        ProductService ProductService { get; set; }
        [Inject]
        ProveedorService ProveedorService { get; set; }
        [Inject]
        MarcaService MarcaService { get; set; }
        [Parameter]
        public ProductoVM? SelectedProduct { get; set; } = new ProductoVM();
        public List<ProveedorVM> Provees;
        public List<MarcaVM> Marcas;
        [Parameter]
        public EventCallback<ProductoVM> ReturnUpd { get; set; }

        protected override void OnInitialized()
        {
            Provees = ProveedorService.GetProvees();
            Marcas = MarcaService.GetMarcas();

        }

        public async void Save()
        {
            if (SelectedProduct != null)
            {
                await ProductService.SaveProductAsync(SelectedProduct);
            }

            ReturnUpd.InvokeAsync();
        }

        public async Task CancelUpd()
        {
            ReturnUpd.InvokeAsync();
        }
    }
}
