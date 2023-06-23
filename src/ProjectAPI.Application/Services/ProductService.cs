using AutoMapper;
using ProjectAPI.Application.DTOs;
using ProjectAPI.Application.DTOs.Validations;
using ProjectAPI.Application.Services.Interfaces;
using ProjectAPI.Domain.Entities;
using ProjectAPI.Domain.Repositories.Interfaces;

namespace ProjectAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail<ProductDTO>("Object need be informate");

            var result = new ProductDTOValidator().Validate(productDTO);
            if (!result.IsValid)
                return ResultService.RequestError<ProductDTO>("Problem of the validate!", result);

            var product = _mapper.Map<Product>(productDTO);
            var data = await _productRepository.CreateAsync(product);
            return ResultService.Ok(_mapper.Map<ProductDTO>(data));
        }

        public async Task<ResultService<ICollection<ProductDTO>>> GetAsync(int pageNumber = 0, int pageQuantity = int.MaxValue)
        {
            var products = await _productRepository.GetAllASync(pageNumber, pageQuantity);
            return ResultService.Ok(_mapper.Map<ICollection<ProductDTO>>(products));
        }

        public async Task<ResultService<ProductDTO>> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return ResultService.Fail<ProductDTO>("Product not found!");
            return ResultService.Ok(_mapper.Map<ProductDTO>(product));
        }

        public async Task<ResultService> UpdateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail("Product need be informate");

            var validation = new ProductDTOValidator().Validate(productDTO);

            if (!validation.IsValid)
                return ResultService.RequestError("Problem with the field validation", validation);

            var product = await _productRepository.GetByIdAsync(productDTO.Id);
            if (product == null)
                return ResultService.Fail("Product not found!");

            product = _mapper.Map<ProductDTO, Product>(productDTO, product);
            await _productRepository.UpdateAsync(product);
            return ResultService.Ok("Product edited!");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return ResultService.Fail("Product is not found!");

            await _productRepository.DeleteAsync(product);
            return ResultService.Ok($"Product to id: {id} was Deleted!");
        }
    }
}
