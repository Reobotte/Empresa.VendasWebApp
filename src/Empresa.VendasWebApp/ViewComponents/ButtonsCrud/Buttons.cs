using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Empresa.VendasWebApp.ViewComponents.ButtonsCrud
{
    public abstract class Buttons : ViewComponent
    {
        protected async Task<ButtonCrud> GetButtonCrud(string title) =>
            new ButtonCrud { Titulo = title };
    }
}
