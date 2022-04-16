using Empresa.VendasWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.VendasWebApp.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IProdutoApiService _api;

        public ProdutoServices(IProdutoApiService api) =>
            _api = api;

        public async Task<IEnumerable<ProdutoIdViewModel>> GetAll() =>
            await _api.GetAll();

        public async Task<IEnumerable<ProdutoCategoriaViewModel>> GetProdutosCategoria(Guid? categoriaId) =>
            await _api.GetProdutosCategoria(categoriaId);

        public async Task<ProdutoCategoriaViewModel> GetProdutoCategoria(Guid id) =>
            await _api.GetProdutoCategoria(id);

        public async Task<ProdutoIdViewModel> Get(Guid id) =>
                await _api.Get(id);

        public async Task<ProdutoIdViewModel> Post(ProdutoViewModel viewModel)
        {
            var response = await _api.Post(viewModel);
            Set(response);
            return response;
        }

        public async Task<ProdutoIdViewModel> Put(ProdutoIdViewModel viewModel)
        {
            var response = await _api.Put(
                viewModel.Id,
                viewModel);
            Set(response);
            return response;
        }

        public async Task Delete(Guid id) =>
            await _api.Delete(id);

        private void Set(ProdutoIdViewModel viewModel)
        {
            viewModel.Id = viewModel.Produto.Id;
            viewModel.Descricao = viewModel.Produto?.Descricao;
        }
    }
}
