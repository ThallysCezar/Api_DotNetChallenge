using AutoMapper;
using ProjectAPI.Application.DTOs;
using ProjectAPI.Domain.Entities;

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
