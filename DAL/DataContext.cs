using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArcherLogic_Salon_Solution.DAL
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<UserDAL> user { get; set; }
        public virtual DbSet<MediaDAL> media { get; set; }
        public virtual DbSet<PhotoDAL> photo { get; set; }
    }
}
