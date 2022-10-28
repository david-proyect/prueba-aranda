using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    [Table("Products", Schema = "CatalogProducts")]
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ImgUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }

    }
}
