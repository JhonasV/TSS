using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSS.Interfaces.Services
{
    public interface IService<T> where T: class
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task SaveAsync(T entity);
    }
}
