using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcherLogic_Salon_Solution.DAL
{
    public interface IPhotoRepository
    {
        Task Add(PhotoDAL entity);
    }

    public class PhotoRepository : IPhotoRepository
    {
        private readonly DataContext context;
        private readonly DbSet<PhotoDAL> dbSet;

        public PhotoRepository(DataContext context)
        {
            this.context = context;
            dbSet = context.Set<PhotoDAL>();
        }

        public virtual async Task Add(PhotoDAL entity)
        {
            context.Set<PhotoDAL>().Add(entity);
            await context.SaveChangesAsync();
        }
    }
}
