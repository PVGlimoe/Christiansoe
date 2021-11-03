using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Christiansoe.Models;

namespace Christiansoe.Data
{
    public class ChristiansoeContext : DbContext
    {
        public ChristiansoeContext (DbContextOptions<ChristiansoeContext> options)
          
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=phillipkea.database.windows.net;Initial Catalog=Christiansoe;Persist Security Info=True;User ID=phillip;Password=Kea@1234");
        }

        public DbSet<Route> Route { get; set; }

        public DbSet<Map> Map { get; set; }

        public DbSet<Field> Field { get; set; }

        public DbSet<BingoBoard> BingoBoard { get; set; }

        public DbSet<Christiansoe.Models.Theme> Theme { get; set; }
    }



}
