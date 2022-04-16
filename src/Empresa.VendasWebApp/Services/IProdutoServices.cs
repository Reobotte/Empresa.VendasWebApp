using Empresa.VendasWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.VendasWebApp.Services
{
    public interface IProdutoServices
        : IApiService<ProdutoIdViewModel, ProdutoViewModel>
    {
        Task<IEnumerable<ProdutoCategoriaViewModel>> GetProdutosCategoria(Guid? categoriaId = null);
        Task<ProdutoCategoriaViewModel> GetProdutoCategoria(Guid id);
    }
}
