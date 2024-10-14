using Microsoft.JSInterop;
using System.Threading.Tasks;
using static Inicio.Client.Pages.TDocumento.ListaTdocumento;

public class AlertaServicio
{
    private readonly IJSRuntime _jsRuntime;

    public AlertaServicio(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<SwalResult> ConfirmDeletion(string title, string text)
    {
        return await _jsRuntime.InvokeAsync<SwalResult>("Swal.fire", new
        {
            title,
            text,
            icon = "warning",
            showCancelButton = true,
            confirmButtonColor = "#3085d6",
            cancelButtonColor = "#d33",
            confirmButtonText = "Sí, eliminarlo!",
            cancelButtonText = "Cancelar"
        });
    }
}
