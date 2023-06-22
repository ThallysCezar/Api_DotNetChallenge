using AutoMapper;
using ProjectAPI.Application.DTOs;
using ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAPI.Application.Mappings
{
    public class DTOToDomainMapping : Profile
    {
        public DTOToDomainMapping()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<StoreDTO, Store>();
            CreateMap<StockItemDTO, StockItem>();
        }
    }
}
