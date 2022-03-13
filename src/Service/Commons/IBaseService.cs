using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Commons
{
    public interface IBaseService<T,E> where T: class
    {
        Task<T> Create(E model);
        Task<T> GetById(int id);

        Task Update(int id, E model);
        Task<DataCollection<T>> GetAll(int page, int take);
        Task Delete(int id);

    }
}
