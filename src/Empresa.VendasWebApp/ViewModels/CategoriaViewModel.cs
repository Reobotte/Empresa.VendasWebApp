using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Empresa.VendasWebApp.ViewModels
{
    public class CategoriaViewModel
    {
        [Required(ErrorMessage = "A {0} é obrigatória!")]
        [StringLength(80, ErrorMessage = "A {0} deve ter possuir entre {2} a {1} caracteres!", MinimumLength = 3)]
        [DisplayName("Categoria")]
        public string Descricao { get; set; }

        public CategoriaIdViewModel Categoria { get; set; }
        public string Get { get; set; }
    }
}
