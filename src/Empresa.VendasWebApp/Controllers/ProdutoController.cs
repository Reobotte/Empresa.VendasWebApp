using Empresa.VendasWebApp.Services;
using Empresa.VendasWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.VendasWebApp.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoServices _services;

        public ProdutoController(IProdutoServices services) =>
            _services = services;

        // GET: ProdutoController
        public async Task<IActionResult> Index() =>
            View(await _services.GetProdutosCategoria());

        // GET: ProdutoController/Details/5
        public async Task<IActionResult> Details(Guid id) =>
            View(await _services.GetProdutoCategoria(id));

        // GET: ProdutoController/Create
        public async Task<IActionResult> Create([FromServices] ICategoriaServices categoriasServices) =>
            View(new ProdutoCategoriaViewModel
            {
                Categorias = await categoriasServices.GetAll()
            });

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoCategoriaViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // ToDo :  Recuperar lista de categorias
                    AddErrors();
                    return View(viewModel);
                }
                await _services.Post(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // ToDo :  Recuperar lista de categorias
                return View(viewModel);
            }
        }

        // GET: ProdutoController/Edit/5
        public async Task<IActionResult> Edit(Guid id, [FromServices] ICategoriaServices categoriasServices)
        {
            var response = await _services.Get(id);
            var categorias = await categoriasServices.GetAll();
            return View(new ProdutoCategoriaViewModel
            {
                Id = response.Id,
                Descricao = response.Descricao,
                Preco = response.Preco,
                Status = response.Status,
                CategoriaId = response.CategoriaId,
                Categorias = categorias
            });
        }

        // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            Guid id, ProdutoCategoriaViewModel viewModel, [FromServices] ICategoriaServices categoriasServices)
        {
            if (id != viewModel.Id)
            {
                // ToDo :  Recuperar lista de categorias
                AddModelErro("Erro ao alterar!!!");
                return View(viewModel);
            }
            if (!ModelState.IsValid)
            {
                // ToDo :  Recuperar lista de categorias
                AddErrors();
                return View(viewModel);
            }

            try
            {
                await _services.Put(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                // ToDo :  Recuperar lista de categorias
                AddModelErro(e.Message);
                return View(viewModel);
            }
        }

        // GET: ProdutoController/Delete/5
        public async Task<IActionResult> Delete(Guid id) =>
            View(await _services.GetProdutoCategoria(id));

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, ProdutoIdViewModel viewModel)
        {
            try
            {
                await _services.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                AddModelErro(e.Message);
                return View(viewModel);
            }
        }

        #region Private Methods

        private void AddErrors() =>
            AddModelErrors(ModelState.Values
                .Where(x => x.ValidationState == ModelValidationState.Invalid)
                .SelectMany(v => v.Errors)
                .Select(m => m.ErrorMessage)
                .ToList());

        private void AddModelErrors(List<string> erros) =>
            erros.ToList()
                .ForEach(erro => AddModelErro(erro));

        private void AddModelErro(string msg) =>
            ModelState.AddModelError(string.Empty, msg);

        #endregion
    }
}
