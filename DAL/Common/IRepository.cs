using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArcherLogic_Salon_Solution.DAL
{
    public interface IRepository<T> where T:class
    {
        Task<List<UserDAL>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
