using Brazilla.Database.Entities;
using Brazilla.Services.BlendServices.Models;

namespace Brazilla.Services.BlendServices
{
    public interface IBlendService
    {
        void Create(CreateViewModel vm);
        void Update(CoffeeBlendEntity blendEntity);
        void Delete(CoffeeBlendEntity blendEntity);
        void Delete(long id);
        CoffeeBlendEntity GetById(long id);
        List<CoffeeBlendEntity> GetAll();
        List<CoffeeBlendEntity> GetAllNotBuyed();
        List<CoffeeBlendEntity> GetByType(BlendTypeEntity type);
        List<CoffeeBlendEntity> GetByTypeNotBuyed(BlendTypeEntity type);
        List<CoffeeBlendEntity> GetByType(long typeId);
        List<CoffeeBlendEntity> GetByTypeNotBuyed(long typeId);
        void Buy(CoffeeBlendEntity coffeeBlendEntity, long userId);
        void Buy(long blendId, long userId);
        void Cancel(long id);
    }
}