using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArcherLogic_Salon_Solution.DAL
{
    public interface IUserRepository: IRepository<UserDAL>
    {
        Task<UserDAL> GetByIDAsync(int id);
        Task<UserDAL> GetAsync(Expression<Func<UserDAL, bool>> where, params Expression<Func<UserDAL, object>>[] includeExpressions);
    }
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        private DbSet<UserDAL> dbSet;
        public UserRepository(DataContext context)
        {
            this.context = context;
            dbSet = context.Set<UserDAL>();
        }

        public virtual async Task Add(UserDAL entity)
        {
            context.Set<UserDAL>().Add(entity);
            await context.SaveChangesAsync();
        }
        public virtual async Task Update(UserDAL entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public virtual async Task Delete(UserDAL entity)
        {
            context.Set<UserDAL>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<UserDAL> GetByIDAsync(int id)
        {
            return await context.Set<UserDAL>().FindAsync(id);
        }
        public async Task<List<UserDAL>> GetAll()
        {
            return await context.Set<UserDAL>().ToListAsync();
        }
        public async Task<UserDAL> GetAsync(Expression<Func<UserDAL, bool>> where, params Expression<Func<UserDAL, object>>[] includeExpressions)
        {
            return await includeExpressions
                .Aggregate<Expression<Func<UserDAL, object>>, IQueryable<UserDAL>>(dbSet, (current, expression) => current.Include(expression))
                .Where(where)
                .Where(x => x.IS_ACTIVE == 1)
                .FirstOrDefaultAsync();
        }
        //public virtual IQueryable<UserDAL> GetAll(params Expression<Func<UserDAL, object>>[] includeExpressions)
        //{
        //    //return context.Set<T>().AsQueryable();
        //    //return dbSet.ToList();
        //    return includeExpressions
        //        .Aggregate<Expression<Func<UserDAL, object>>, IQueryable<UserDAL>>(dbSet, (current, expression) => current.Include(expression));

        //}
    }
}
