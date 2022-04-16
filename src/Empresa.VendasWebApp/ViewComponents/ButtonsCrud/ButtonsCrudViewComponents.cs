using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Empresa.VendasWebApp.ViewComponents.ButtonsCrud
{
    [ViewComponent(Name="Buttonscrud")]
    public class ButtonsCrudViewComponents : Buttons
    {
        public async Task<IViewComponentResult> InvokeAsync(string title) =>
            View(await GetButtonCrud(title: title));
    }
}
