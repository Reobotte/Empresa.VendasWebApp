using Empresa.VendasWebApp.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.VendasWebApp.Services
{
    /// <summary>
    /// Usando replite, componente para automatizar as chamdas HTTP
    /// Através de uma Interface
    /// </summary>
    public interface IProdutoApiService
    {
        [Get("/api/Produtos/v1")]
        Task<IEnumerable<ProdutoIdViewModel>> GetAll();

        [Get("/api/Produtos/v1/categoria/")]
        Task<IEnumerable<ProdutoCategoriaViewModel>> GetProdutosCategoria(Guid? categoriaId = null);

        [Get("/api/Produtos/v1/categoria/{id}")]
        Task<ProdutoCategoriaViewModel> GetProdutoCategoria(Guid id);

        [Get("/api/Produtos/v1/{id}")]
        Task<ProdutoIdViewModel> Get([AliasAs("id")] Guid id);

        [Post("/api/Produtos/v1")]
        Task<ProdutoIdViewModel> Post([Body] ProdutoViewModel viewModel);

        [Put("/api/Produtos/v1/{id}")]
        Task<ProdutoIdViewModel> Put(
            [AliasAs("id")] Guid id,
            [Body] ProdutoIdViewModel viewModel);

        [Delete("/api/Produtos/v1/{id}")]
        Task Delete([AliasAs("id")] Guid id);
    }
}
