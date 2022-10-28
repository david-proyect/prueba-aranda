using Common.DTO;
using Domain.Services.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        
        /// <summary>
        /// Este metodo se encarga de guardar los productos
        /// </summary>
        /// <param name="product">Objeto de producto</param>
        /// <returns>ok en la peticion</returns>
        [HttpPost("AddProduct")]
        public ActionResult AddProduct([FromForm]ProductDTO product)
        {
            try
            {
                _productServices.AddProduct(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Este metodo se encarga de de actualizar un producto
        /// </summary>
        /// <param name="product">Objeto de producto</param>
        /// <returns></returns>
        [HttpPut("UpdateProduct")]
        public ActionResult UpdateProduct([FromForm] ProductDTO product)
        {
            try
            {
                _productServices.UpdateProduct(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Este metodo se encarga de eliminar un producto
        /// </summary>
        /// <param name="productId">id del producto</param>
        /// <returns></returns>
        [HttpDelete("DeleteProduct")]
        public ActionResult AddProduct(int productId)
        {
            try
            {
                _productServices.DeleteProduct(productId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Este metodo se encarga de devolver un listado de productos
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllProduct")]
        public ActionResult<List<ProductByCategoryDTO>> GetAllProduct()
        {
            try
            {               
                return Ok(_productServices.GetAllProduct());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
