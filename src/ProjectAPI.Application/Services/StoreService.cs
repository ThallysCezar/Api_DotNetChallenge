using AutoMapper;
using ProjectAPI.Application.DTOs;
using ProjectAPI.Application.DTOs.Validations;
using ProjectAPI.Application.Services.Interfaces;
using ProjectAPI.Domain.Entities;
using ProjectAPI.Domain.Repositories.Interfaces;

namespace ProjectAPI.Application.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;


        public StoreService(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<StoreDTO>> CreateAsync(StoreDTO storeDTO)
        {
            if (storeDTO == null)
                return ResultService.Fail<StoreDTO>("Object need be informate");

            var result = new StoreDTOValidator().Validate(storeDTO);
            if (!result.IsValid)
                return ResultService.RequestError<StoreDTO>("Problem of the validate!", result);

            var store = _mapper.Map<Store>(storeDTO);
            var data = await _storeRepository.CreateAsync(store);
            return ResultService.Ok(_mapper.Map<StoreDTO>(data));
        }

        public async Task<ResultService<ICollection<StoreDTO>>> GetAsync(int pageNumber = 0, int pageQuantity = int.MaxValue)
        {
            var stores = await _storeRepository.GetAllASync(pageNumber, pageQuantity);
            return ResultService.Ok(_mapper.Map<ICollection<StoreDTO>>(stores));
        }

        public async Task<ResultService<StoreDTO>> GetByIdAsync(int id)
        {
            var store = await _storeRepository.GetByIdAsync(id);
            if (store == null)
                return ResultService.Fail<StoreDTO>("Store not found!");
            return ResultService.Ok(_mapper.Map<StoreDTO>(store));
        }

        public async Task<ResultService> UpdateAsync(StoreDTO storeDTO)
        {
            if (storeDTO == null)
                return ResultService.Fail("Store need be informate");

            var validation = new StoreDTOValidator().Validate(storeDTO);

            if (!validation.IsValid)
                return ResultService.RequestError("Problem with the field validation", validation);

            var store = await _storeRepository.GetByIdAsync(storeDTO.Id);
            if (store == null)
                return ResultService.Fail("Product not found!");

            store = _mapper.Map<StoreDTO, Store>(storeDTO, store);
            await _storeRepository.UpdateAsync(store);
            return ResultService.Ok("Store edited!");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var store = await _storeRepository.GetByIdAsync(id);
            if (store == null)
                return ResultService.Fail("Store is not found!");

            await _storeRepository.DeleteAsync(store);
            return ResultService.Ok($"Store to id: {id} was Deleted!");
        }
    }
}
