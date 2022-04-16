using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Empresa.VendasWebApp.ViewModels
{
    public class ProdutoViewModel
    {
        [Required(ErrorMessage = "A {0} é obrigatória!")]
        [StringLength(80, ErrorMessage = "A {0} deve ter possuir entre {2} a {1} caracteres!", MinimumLength = 3)]
        [DisplayName("Produto")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [DisplayName("Preço")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório!")]
        [DisplayName("Status")]
        public EnumStatus Status { get; set; }

        [DisplayName("Categoria")]
        public Guid? CategoriaId { get; set; }

        public ProdutoIdViewModel Produto { get; set; }
        public string Get { get; set; }
    }
}
