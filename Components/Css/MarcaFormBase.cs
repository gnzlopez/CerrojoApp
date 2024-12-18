using CerrojoApp.ViewModels;
using CerrojoApp.Services;
using Microsoft.AspNetCore.Components;

namespace CerrojoApp.Components.Css
{
    public class MarcaFormBase : ComponentBase
    {
        [Inject]
        MarcaService MarcaService { get; set; }
        [Parameter]
        public MarcaVM? Marca { get; set; } = new MarcaVM();
        public static List<MarcaVM> Marcas = new List<MarcaVM>();
        protected override async Task OnInitializedAsync()
        {

            Marcas = await MarcaService.GetMarcasAsync();

        }

        public async void Save()
        {
            if (Marca != null)
            {
                await MarcaService.SaveMarcaAsync(Marca);
            }
            Marcas = await MarcaService.GetMarcasAsync();
        }

        public async Task DeleteMarca(MarcaVM marca)
        {
            //TODO: agregar validacion al eliminar
            var confirmed = true;

            if (confirmed)
            {
                await MarcaService.DeleteMarcaAsync(marca.Id);
            }
            Marcas = await MarcaService.GetMarcasAsync();
            StateHasChanged();
        }
    }
}
