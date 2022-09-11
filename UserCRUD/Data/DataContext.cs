using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserCRUD.Model;

namespace UserCRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Escolaridade> Escolaridade { get; set; }

    }
}
