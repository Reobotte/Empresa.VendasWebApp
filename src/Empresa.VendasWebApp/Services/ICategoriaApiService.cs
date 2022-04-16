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
    public interface ICategoriaApiService
    {
        [Get("/api/Categorias/v1")]
        Task<IEnumerable<CategoriaIdViewModel>> GetAll();

        [Get("/api/Categorias/v1/{id}")]
        Task<CategoriaIdViewModel> Get([AliasAs("id")] Guid id);

        [Post("/api/Categorias/v1")]
        Task<CategoriaIdViewModel> Post([Body] CategoriaViewModel viewModel);

        [Put("/api/Categorias/v1/{id}")]
        //[Put("/api/Categorias/v1")]
        Task<CategoriaIdViewModel> Put(
            [AliasAs("id")] Guid id,
            [Body] CategoriaIdViewModel viewModel);

        [Delete("/api/Categorias/v1/{id}")]
        Task Delete([AliasAs("id")] Guid id);
    }
}
