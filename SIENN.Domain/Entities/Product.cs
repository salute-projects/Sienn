using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SIENN.Domain.Abstraction;

namespace SIENN.Domain.Entities
{
    public class Product : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        public long Code { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public double Price { get; set; }

        public bool IsAvailable { get; set; }

        public DateTimeOffset DeliveryDate { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Updated { get; set; }

        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }
        [JsonIgnore]
        public ProductType Type { get; set; }

        [ForeignKey(nameof(Unit))]
        public int UnitId { get; set; }
        [JsonIgnore]
        public Unit Unit { get; set; }

        [JsonIgnore]
        public ICollection<ProductCategoryLink> Categories { get; set; } = new List<ProductCategoryLink>();
    }
}
