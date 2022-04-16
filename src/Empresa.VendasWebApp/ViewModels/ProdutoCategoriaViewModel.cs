using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Empresa.VendasWebApp.ViewModels
{
    public class ProdutoCategoriaViewModel : ProdutoIdViewModel
    {
        public CategoriaIdViewModel Categoria { get; set; }

        public IEnumerable<CategoriaIdViewModel> Categorias { get; set; }
        public IEnumerable<SelectListItem> CategoriaSelectList =>
            new SelectList(Categorias, "Id", "Descricao");

        public ProdutoCategoriaViewModel() =>
            Categorias = new Collection<CategoriaIdViewModel>();
    }
}
