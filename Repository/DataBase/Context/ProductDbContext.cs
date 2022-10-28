using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Model;
using Repository.Model.Views;

namespace Repository.DataBase.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        public DbSet<ProductModel> Product { get; set;  }
        public DbSet<ViewProductsCatalog> ViewProductsCatalog { get; set; }
    }
}
