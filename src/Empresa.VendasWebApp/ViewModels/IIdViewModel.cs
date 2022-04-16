using System;

namespace Empresa.VendasWebApp.ViewModels
{
    public interface IIdViewModel
    {
        //[Required(ErrorMessage = "O {0} é obrigatório!")]
        //[DisplayName("Id")]
        Guid Id { get; set; }
    }
}
