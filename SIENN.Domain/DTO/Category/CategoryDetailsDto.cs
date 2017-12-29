using System;
using System.Collections.Generic;

namespace SIENN.Domain.DTO.Category
{
    public class CategoryDetailsDto
    {
        public int Id { get; set; }
        public long Code { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public ICollection<Entities.Product> Products { get; set; } = new List<Entities.Product>();
    }
}
