using Brazilla.Database.Entities;
using Brazilla.EntityFramework.Repository;
using Brazilla.Services.BlendTypeServices.Models;
using Microsoft.EntityFrameworkCore;

namespace Brazilla.Services.BlendTypeServices
{
    public class BlendTypeService : IBlendTypeService
    {
        private readonly IGenericRepository<BlendTypeEntity> _genericRepository;

        public BlendTypeService(IGenericRepository<BlendTypeEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public bool Create(SettingsViewModel vm)
        {
            BlendTypeEntity blendTypesEntity = new BlendTypeEntity()
            {
                Arabica = vm.Arabica,
                Name = vm.Name,
                Robusta = vm.Robusta,
                CreatedOn = DateTime.Now,
            };

            BlendTypeEntity fromDb = _genericRepository.Table
                .FirstOrDefault(type => type.Name == blendTypesEntity.Name);

            if(fromDb != null)
            {
                return false;
            }

            _genericRepository.Create(blendTypesEntity);
            return true;
        }
        
        public void Delete(BlendTypeEntity blendTypesEntity)
        {
            blendTypesEntity.DeletedOn = DateTime.Now;
            Update(blendTypesEntity);
        }

        public void Delete(long id)
        {
            BlendTypeEntity blendTypeEntity = _genericRepository.Table.FirstOrDefault(type => type.Id == id);
            if(blendTypeEntity == null)
            {
                return;
            }

            _genericRepository.Remove(blendTypeEntity);
        }

        public List<BlendTypeEntity> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public BlendTypeEntity GetById(long id)
        {
            return _genericRepository.Table
                .FirstOrDefault(type => type.Id == id);
        }

        public BlendTypeEntity GetByName(string name)
        {
            return _genericRepository.Table
                .FirstOrDefault(type => type.Name == name);
        }

        public void Update(BlendTypeEntity blendTypesEntity)
        {
            _genericRepository.Update(blendTypesEntity);
        }
    }
}