using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Common
{
    public interface IWriteRepository<T>:IRepository<T> 
        where T : BaseEntity
    {

        Task<bool> AddAsync(T model);
        Task<bool> AddAsync(List<T> model);
        bool Update(T model);
        Task<bool> Remove(string id);
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        Task<int> SaveAsync();
    }
}
