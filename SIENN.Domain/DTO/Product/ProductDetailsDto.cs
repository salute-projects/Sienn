using System;
using System.Collections.Generic;
using SIENN.Domain.DTO.Category;
using SIENN.Domain.DTO.ProductType;
using SIENN.Domain.DTO.Unit;

namespace SIENN.Domain.DTO.Product
{
    public class ProductDetailsDto
    {
        public int Id { get; set; }
        public long Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public ProductTypeSummaryDto Type { get; set; }
        public UnitSummaryDto Unit { get; set; }
        public IEnumerable<CategorySummaryDto> Categories { get; set; } = new List<CategorySummaryDto>();
    }
}
