using Empresa.VendasWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.VendasWebApp.Services
{
    public class CategoriaServices : ICategoriaServices
    {
        private readonly ICategoriaApiService _api;

        public CategoriaServices(ICategoriaApiService api) =>
            _api = api;

        public async Task<IEnumerable<CategoriaIdViewModel>> GetAll() =>
            await _api.GetAll();

        public async Task<CategoriaIdViewModel> Get(Guid id) =>
            await _api.Get(id);

        public async Task<CategoriaIdViewModel> Post(CategoriaViewModel viewModel)
        {
            var response = await _api.Post(viewModel);
            Set(response);
            return response;
        }

        public async Task<CategoriaIdViewModel> Put(CategoriaIdViewModel viewModel)
        {
            var response = await _api.Put(
                viewModel.Id, 
                viewModel);
            Set(response);
            return response;
        }

        public async Task Delete(Guid id) =>
            await _api.Delete(id);

        private void Set(CategoriaIdViewModel viewModel)
        {
            viewModel.Id = viewModel.Categoria.Id;
            viewModel.Descricao = viewModel.Categoria?.Descricao;
        }
    }
}
