using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArcherLogic_Salon_Solution.DAL
{
    public interface IMediaRepository
    {
        Task<List<MediaDAL>> GetAll();
    }

    public class MediaRepository : IMediaRepository
    {
        private readonly DataContext context;
        private DbSet<MediaDAL> dbSet;
        public MediaRepository(DataContext context)
        {
            this.context = context;
            dbSet = context.Set<MediaDAL>();
        }
        public async Task<List<MediaDAL>> GetAll()
        {
            return await context.Set<MediaDAL>().ToListAsync();
        }
    }    
}
