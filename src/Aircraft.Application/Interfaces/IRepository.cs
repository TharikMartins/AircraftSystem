using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aircraft.Application.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get(Guid Id);
        Task<bool> Insert(T Model);
    }
}
