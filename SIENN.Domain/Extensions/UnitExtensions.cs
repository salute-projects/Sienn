using SIENN.Domain.DTO.Unit;
using SIENN.Domain.Entities;

namespace SIENN.Domain.Extensions
{
    public static class UnitExtensions
    {
        public static Unit ToEntity(this AddUnitDto dto)
        {
            return new Unit
            {
                Description = dto.Description,
                Code = dto.Code
            };
        }

        public static UnitSummaryDto ToSummary(this Unit unit)
        {
            return new UnitSummaryDto
            {
                Code = unit.Code,
                Description = unit.Description,
                Id = unit.Id
            };
        }
    }
}
