using Brazilla.Database.Entities;
using Brazilla.Services.BlendTypeServices.Models;

namespace Brazilla.Services.BlendTypeServices
{
    public interface IBlendTypeService
    {
        bool Create(SettingsViewModel vm);
        void Update(BlendTypeEntity blendTypesEntity);
        void Delete(BlendTypeEntity blendTypesEntity);
        void Delete(long id);
        BlendTypeEntity GetById(long id);
        BlendTypeEntity GetByName(string name);
        List<BlendTypeEntity> GetAll();
    }
}