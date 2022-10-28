using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.DTO;
using Common.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repository.Model;
using Repository.Repository.Product;
using Repository.Repository.Views;

namespace Domain.Services.Product
{
    public interface IProductServices
    {
        void AddProduct(ProductDTO product);
        void DeleteProduct(int productId);
        void UpdateProduct(ProductDTO product);
        List<ProductByCategoryDTO> GetAllProduct();
    }
    public class ProductServices : IProductServices
    {
        private IProductRepository _productRepository;
        private IViewProductsCatalogRepository _viewProductsCatalogRepository;

        public readonly IMapper _mapper;
        public ProductServices(IProductRepository productRepository,
            IViewProductsCatalogRepository viewProductsCatalogRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _viewProductsCatalogRepository = viewProductsCatalogRepository;
            _mapper = mapper;
        }

        public List<ProductByCategoryDTO> GetAllProduct()
        {
            return _mapper.Map<List<ProductByCategoryDTO>>(_viewProductsCatalogRepository.GetAllProductByCategory());
        }

        /// <summary>
        /// Este metodo se encarga mapear y invocar el metodo que almacena los productos
        /// </summary>
        /// <param name="product">Producto</param>
        public void AddProduct(ProductDTO product)
        {
            string urlImage = GetUrlImage(product.Files);
            ProductModel infoProduct = _mapper.Map<ProductModel>(product);
            infoProduct.CreationDate = DateTimeColombiaHelper.GetDateTimeColombia();
            infoProduct.ImgUrl = urlImage;
            _productRepository.AddProduct(infoProduct);
        }

        /// <summary>
        /// Este metodo se encarga de mapear y invocar le metodo que actualiza el producto
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(ProductDTO product)
        {
            ProductModel? findProduct = _productRepository.FindProduct(product.ProductId);
            if (findProduct.ImgUrl != product.ImgUrl)
            {
                string urlImage = GetUrlImage(product.Files);
                product.ImgUrl = urlImage;
            }

            ProductModel infoProduct = _mapper.Map<ProductModel>(product);
            infoProduct.UpdateDate = DateTimeColombiaHelper.GetDateTimeColombia();
            infoProduct.CreationDate = findProduct.CreationDate;
            _productRepository.UpdateProduct(infoProduct);
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }

        /// <summary>
        /// Metodo que se encarga de almacenar las imagenes
        /// </summary>
        /// <param name="files">List<IFormFile> files</param>
        /// <returns>Devuelve la url del imagen donde queda guardada</returns>
        public string GetUrlImage(List<IFormFile> files)
        {
            string filePath = string.Empty;

            if (files.Any())
            {
                foreach (IFormFile file in files)
                {
                    filePath = Path.GetTempPath() + file.FileName;
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(stream);
                    }
                }             
            }
            return filePath;
        }
    }
}
