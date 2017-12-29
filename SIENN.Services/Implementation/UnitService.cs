using System;
using SIENN.DbAccess.Abstraction;
using SIENN.DbAccess.Repositories.Abstraction;
using SIENN.Domain.DTO.Unit;
using SIENN.Domain.Entities;
using SIENN.Services.Abstraction;

namespace SIENN.Services.Implementation
{
    public class UnitService : DataService<Unit, IUnitRepository>, IUnitService
    {
        public UnitService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override void Initialize(out IUnitRepository repository)
        {
            repository = UnitOfWork.Units;
        }

        public void Update(UpdateUnitDto dto)
        {
            var unit = GetById(dto.Id);
            if (unit == null)
                throw new Exception("Unit not found");
            unit.Code = dto.Code;
            unit.Description = dto.Description;
            base.Update(unit);
        }
    }
}
