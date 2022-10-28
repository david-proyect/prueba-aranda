﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class ProductCategoryModel
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
