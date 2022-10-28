using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Common.DTO
{
    public class ProductDTO
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string? ProductName { get; set; }
        /// <summary>
        /// Descripcion del producto
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Categoria id
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Ruta de la imagen
        /// </summary>
        public string? ImgUrl { get; set; }
        /// <summary>
        /// Archivos
        /// </summary>
        public List<IFormFile>? Files { get; set; }

    }
}
