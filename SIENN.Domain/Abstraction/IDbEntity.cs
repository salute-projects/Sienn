using System;

namespace SIENN.Domain.Abstraction
{
    public interface IDbEntity
    {
        int Id { get; set; }

        DateTimeOffset Created { get; set; }

        DateTimeOffset Updated { get; set; }
    }
}