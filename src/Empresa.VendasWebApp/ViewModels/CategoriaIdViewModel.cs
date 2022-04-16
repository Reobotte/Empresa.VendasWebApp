using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Empresa.VendasWebApp.ViewModels
{
    public class CategoriaIdViewModel 
        : CategoriaViewModel, IIdViewModel
    {
        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [DisplayName("Id")]
        public Guid Id { get; set; }
    }
}
