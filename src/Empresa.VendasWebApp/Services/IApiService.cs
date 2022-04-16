using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.VendasWebApp.Services
{
    public interface IApiService<TID, T> 
        where TID : class
        where T : class
    {
        Task<IEnumerable<TID>> GetAll();

        Task<TID> Get(Guid id);

        Task<TID> Post(T viewModel);

        Task<TID> Put(TID viewModel);

        Task Delete(Guid id);
    }
}
