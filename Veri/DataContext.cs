using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace neproje.Veri
{
    public class DataContext: DbContext
    {
      

        public DataContext(DbContextOptions<DataContext> options): base(options)
        { }
        public DbSet<About> Aboats => Set<About>();
        public DbSet<Content> Contents =>Set<Content>();
        public DbSet<Facts> Facts =>Set<Facts>();
        public DbSet<Galeri> Galeris =>Set<Galeri>();
        public DbSet<Progres> Progres =>Set<Progres>();
        public DbSet<User> users =>Set<User>();
       

        

    }
}