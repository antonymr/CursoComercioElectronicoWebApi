using AutoMapper;
using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using Curso.ComercioElectronico.Aplicacion.Exceptions;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using FluentValidation;

namespace Curso.ComercioElectronico.Aplicacion.ServicesImpl
{
    public class DeliveryMethodAppService : IDeliveryMethodAppService
    {
        private readonly IGenericRepository<DeliveryMethod> deliveryMethodRepository;
        private readonly IMapper mapper;
        private readonly IValidator<CreateDeliveryMethodDto> validator;

        public DeliveryMethodAppService(IGenericRepository<DeliveryMethod> repository, IMapper mapper, IValidator<CreateDeliveryMethodDto> validator)
        {
            deliveryMethodRepository = repository;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<ICollection<DeliveryMethodDto>> GetAllAsync()
        {
            var query = await deliveryMethodRepository.GetAsync();
            var result = query.Where(x => x.IsDeleted == false).Select(x => mapper.Map<DeliveryMethodDto>(x));
            return result.ToList();
        }

        public async Task<DeliveryMethodDto> GetByIdAsync(string code)
        {
            var DeliveryMethod = await deliveryMethodRepository.GetByIdAsync(code);
            if (DeliveryMethod == null || DeliveryMethod.IsDeleted == true)
                throw new NotFoundException($"Marca con codigo {code} no encontrado.");
            var DeliveryMethodDto = mapper.Map<DeliveryMethodDto>(DeliveryMethod);
            return DeliveryMethodDto;
        }

        public async Task DeleteAsync(string code)
        {
            var DeliveryMethod = await deliveryMethodRepository.GetByIdAsync(code);
            if (DeliveryMethod == null || DeliveryMethod.IsDeleted == true)
                throw new NotFoundException($"Marca con codigo {code} no encontrado.");
            DeliveryMethod.IsDeleted = true;
            DeliveryMethod.ModifiedDate = DateTime.Now;
            await deliveryMethodRepository.UpdateAsync(DeliveryMethod);
        }

        public async Task UpdateAsync(string code, CreateDeliveryMethodDto DeliveryMethodDto)
        {
            await validator.ValidateAndThrowAsync(DeliveryMethodDto);
            var DeliveryMethod = await deliveryMethodRepository.GetByIdAsync(code);
            if (DeliveryMethod == null || DeliveryMethod.IsDeleted == true)
                throw new NotFoundException($"Marca con codigo {code} no encontrado.");
            DeliveryMethod.Code = DeliveryMethodDto.Code;
            DeliveryMethod.Name = DeliveryMethodDto.Name;
            DeliveryMethod.Description = DeliveryMethodDto.Description;
            DeliveryMethod.ModifiedDate = DateTime.Now;
            await deliveryMethodRepository.UpdateAsync(DeliveryMethod);
        }

        public async Task CreateAsync(CreateDeliveryMethodDto DeliveryMethodDto)
        {
            await validator.ValidateAndThrowAsync(DeliveryMethodDto);
            var exists = await deliveryMethodRepository.GetByIdAsync(DeliveryMethodDto.Code);
            if (exists != null)
                throw new BusinessException($"Marca con codigo {DeliveryMethodDto.Code} ya existe.");
            var DeliveryMethod = mapper.Map<DeliveryMethod>(DeliveryMethodDto);
            DeliveryMethod.CreationDate = DateTime.Now;
            await deliveryMethodRepository.CreateAsync(DeliveryMethod);
        }
    }
}
