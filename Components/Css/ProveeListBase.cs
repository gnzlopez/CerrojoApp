using CerrojoApp.Services;
using CerrojoApp.ViewModels;
using Microsoft.AspNetCore.Components;

namespace CerrojoApp.Components.Css
{
    public class ProveeListBase : ComponentBase
    {
        [Inject]
        ProveedorService ProveedorService { get; set; }
        public static List<ProveedorVM> Proveedores = new List<ProveedorVM>();
        protected override async Task OnInitializedAsync()
        {

            Proveedores = await ProveedorService.GetProveesAsync();

        }

        public async Task DeleteProvee(ProveedorVM provee)
        {
            //TODO: agregar validacion al eliminar
            var confirmed = true;

            if (confirmed)
            {
                await ProveedorService.DeleteProveeAsync(provee.Id);
            }
            Proveedores = await ProveedorService.GetProveesAsync();
            StateHasChanged();
        }
    }
}
