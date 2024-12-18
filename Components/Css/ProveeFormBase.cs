using CerrojoApp.ViewModels;
using CerrojoApp.Services;
using Microsoft.AspNetCore.Components;

namespace CerrojoApp.Components.Css
{
    public class ProveeFormBase : ComponentBase
    {
        [Inject]
        ProveedorService ProveedorService { get; set; }
        [Parameter]
        public ProveedorVM? Proveedor { get; set; } = new ProveedorVM();

        public async void Save()
        {
            if (Proveedor != null)
            { 
                    await ProveedorService.SaveProveeAsync(Proveedor);
            }
        }
    }
}
