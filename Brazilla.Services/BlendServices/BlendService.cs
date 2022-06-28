using Brazilla.Database.Entities;
using Brazilla.EntityFramework.Repository;
using Brazilla.Services.BlendServices.Models;
using Brazilla.Services.BlendTypeServices;
using Microsoft.EntityFrameworkCore;

namespace Brazilla.Services.BlendServices
{
    public class BlendService : IBlendService
    {
        private readonly IGenericRepository<CoffeeBlendEntity> _genericRepository;
        private readonly IBlendTypeService _blendTypeService;

        public BlendService(IGenericRepository<CoffeeBlendEntity> genericRepository,
            IBlendTypeService blendTypeService)
        {
            _genericRepository = genericRepository;
            _blendTypeService = blendTypeService;
        }

        public void Buy(long userId)
        {
            throw new NotImplementedException();
        }

        public async void Create(CreateViewModel vm)
        {
            BlendTypeEntity type = _blendTypeService.GetById(vm.SelectedType);
            
            CoffeeBlendEntity blend = new CoffeeBlendEntity()
            {
                CreatedOn = DateTime.Now,
                Description = vm.Description,
                Left = vm.Left,
                Name = vm.Name,
                Price = vm.Price,
                Weight = vm.Weight,
                Type = type,
                TypeFK = type.Id,
            };

            _genericRepository.Create(blend);
        }

        public void Delete(CoffeeBlendEntity blendEntity)
        {
            blendEntity.DeletedOn = DateTime.Now;
            Update(blendEntity);
        }

        public void Delete(long id)
        {
            CoffeeBlendEntity coffeeBlendEntity = GetById(id);
            _genericRepository.Remove(coffeeBlendEntity);
        }

        public List<CoffeeBlendEntity> GetAll()
        {
            return _genericRepository.Table
                .Include(blend => blend.Type)
                .ToList();
        }

        public CoffeeBlendEntity GetById(long id)
        {
            return _genericRepository.Table
                .Include(blend => blend.Type)
                .FirstOrDefault(blend => blend.Id == id);
        }

        public List<CoffeeBlendEntity> GetByType(BlendTypeEntity type)
        {
            return _genericRepository.Table
                .Where(blend => blend.Type.Name == type.Name || blend.Type.Id == type.Id)
                .ToList();
        }

        public List<CoffeeBlendEntity> GetByType(long typeId)
        {
            BlendTypeEntity type = _blendTypeService.GetById(typeId);
            return GetByType(type);
        }

        public void Update(CoffeeBlendEntity blendEntity)
        {
            _genericRepository.Update(blendEntity);
        }

        public void Buy(CoffeeBlendEntity coffeeBlendEntity, long userId)
        {
            coffeeBlendEntity.UserFK = userId;
            coffeeBlendEntity.Left--;
            Update(coffeeBlendEntity);
        }

        public void Buy(long blendId, long userId)
        {
            CoffeeBlendEntity blend = GetById(blendId);
            if (blend == null)
            {
                return;
            }

            blend.UserFK = userId;
            blend.Left--;
            Update(blend);
        }

        public List<CoffeeBlendEntity> GetAllNotBuyed()
        {
            return _genericRepository.Table
                .Include(blend => blend.Type)
                .Where(blend => blend.Left > 0)
                .ToList();
        }

        public List<CoffeeBlendEntity> GetByTypeNotBuyed(BlendTypeEntity type)
        {
            return _genericRepository.Table
                .Include(blend => blend.Type)
                .Where(blend => blend.Left > 0 && (blend.Type.Name == type.Name || blend.Type.Id == type.Id))
                .ToList();
        }

        public List<CoffeeBlendEntity> GetByTypeNotBuyed(long typeId)
        {
            return _genericRepository.Table
                .Include(blend => blend.Type)
                .Where(blend => blend.Left > 0 && blend.Type.Id == typeId)
                .ToList();
        }

        public void Cancel(long id)
        {
            CoffeeBlendEntity blend = GetById(id);
            if(blend == null)
            {
                return;
            }

            blend.UserFK = null;
            blend.Left++;
            Update(blend);
        }
    }
}