using AutoMapper;
using ProjectAPI.Application.DTOs;
using ProjectAPI.Domain.Entities;

namespace ProjectAPI.Application.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Store, StoreDTO>();
            CreateMap<StockItem, StockItemDTO>();
        }
    }
}
