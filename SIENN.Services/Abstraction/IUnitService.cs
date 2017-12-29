using SIENN.Domain.DTO.Unit;
using SIENN.Domain.Entities;

namespace SIENN.Services.Abstraction
{
    public interface IUnitService : IDataService<Unit>
    {
        void Update(UpdateUnitDto dto);
    }
}