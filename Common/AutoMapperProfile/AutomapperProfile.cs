using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.DTO;
using Repository.Model;
using Repository.Model.Views;

namespace Common.AutoMapperProfile
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ProductDTO, ProductModel>().ReverseMap();
            CreateMap<ProductByCategoryDTO, ViewProductsCatalog>().ReverseMap();
        }
    }
}
