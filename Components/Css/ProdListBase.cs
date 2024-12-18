using CerrojoApp.Services;
using CerrojoApp.ViewModels;
using Microsoft.AspNetCore.Components;

namespace CerrojoApp.Components.Css
{
    public class ProdListBase : ComponentBase
    {
        [Inject]
        ProductService ProductService { get; set; }

        public bool showFormComponent = false;
        public ProductoVM selectedProduct = new ProductoVM();
        public static List<ProductoVM> Products = new List<ProductoVM>();
        protected override async Task OnInitializedAsync()
        {

            Products = await ProductService.GetProductsAsync();

        }

        public void Select(ProductoVM prod)
        {
            selectedProduct = prod;
            showFormComponent = true;
        }

        public async Task ReturnUpdate()
        {
            selectedProduct = new ProductoVM();
            showFormComponent = false;
            StateHasChanged();
        }

        public async Task DeleteProd(ProductoVM prod)
        {
            //TODO: agregar validacion al eliminar
            var confirmed = true;

            if (confirmed)
            {
                await ProductService.DeleteProductAsync(prod.Id);
            }
            Products = await ProductService.GetProductsAsync();
            StateHasChanged();
        }
    }
}
