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
    public class CategoriaController : Controller
    {
        private readonly ICategoriaServices _services;

        public CategoriaController(ICategoriaServices services) =>
            _services = services;

        // GET: CategoriaController
        public async Task<IActionResult> Index() =>
            View(await _services.GetAll());

        // GET: CategoriaController/Details/5
        public async Task<IActionResult> Details(Guid id) =>
            View(await _services.Get(id));

        // GET: CategoriaController/Create
        public IActionResult Create() =>
            View(new CategoriaViewModel() );

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    AddErrors();
                    return View(viewModel);
                }
                await _services.Post(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: CategoriaController/Edit/5
        public async Task<IActionResult> Edit(Guid id) =>
            View(await _services.Get(id));

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CategoriaIdViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                AddModelErro("Erro ao alterar!!!");
                return View(viewModel);
            }
            if (!ModelState.IsValid)
            {
                AddErrors();
                return View(viewModel);
            }

            try
            {
                await _services.Put(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                AddModelErro(e.Message);
                return View(viewModel);
            }
        }

        // GET: CategoriaController/Delete/5
        public async Task<IActionResult> Delete(Guid id) =>
            View(await _services.Get(id));

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, CategoriaIdViewModel viewModel)
        {
            try
            {
                await _services.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
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
