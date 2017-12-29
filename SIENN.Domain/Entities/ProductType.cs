using System;
using System.ComponentModel.DataAnnotations;
using SIENN.Domain.Abstraction;

namespace SIENN.Domain.Entities
{
    public class ProductType : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        public long Code { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Updated { get; set; }
    }
}
