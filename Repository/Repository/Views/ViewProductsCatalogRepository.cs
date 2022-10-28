using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.DataBase.Context;

namespace Repository.Repository.Views
{
    public interface IViewProductsCatalogRepository
    {
        IQueryable GetAllProductByCategory();
    }
    public class ViewProductsCatalogRepository : IViewProductsCatalogRepository
    {
        private readonly ProductDbContext _context;
        public ViewProductsCatalogRepository(ProductDbContext context)
        {
            _context = context;
        }

        public IQueryable GetAllProductByCategory()
        {
            return _context.ViewProductsCatalog;
        }
    }
}
