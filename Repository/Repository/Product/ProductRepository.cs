using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.DataBase.Context;
using Repository.Model;

namespace Repository.Repository.Product
{
    public interface IProductRepository
    {
        IQueryable<ProductModel> GetAllProduct();
        void AddProduct(ProductModel productModel);
        void DeleteProduct(int productId);
        void UpdateProduct(ProductModel productModel);
        ProductModel? FindProduct(int productId);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public IQueryable<ProductModel> GetAllProduct()
        {
            return _context.Product.OrderByDescending(x => x.ProductName);
        }

        /// <summary>
        /// Este metodo se encarga de guardar en base de datos un producto
        /// </summary>
        /// <param name="productModel"></param>
        public void AddProduct(ProductModel productModel)
        {
           _context.Product.Add(productModel);
           _context.SaveChanges();
        }

        /// <summary>
        /// Este metodo se encarga de actualizar un producto
        /// </summary>
        /// <param name="productModel"></param>
        public void UpdateProduct(ProductModel productModel)
        {
            _context.Update(productModel);
            _context.SaveChanges();
        }

        /// <summary>
        /// Este metodo se encarga de eliminar un producto
        /// </summary>
        /// <param name="productId"></param>
        public void DeleteProduct(int productId)
        {
            _context.Product.Remove(FindProduct(productId));
            _context.SaveChanges();
        }

        /// <summary>
        /// Este metodo se encarga de consultar un producto por id de producto
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductModel? FindProduct(int productId)
        {
            return _context.Product.Where(x => x.ProductId == productId).FirstOrDefault();
        }
    }
}
