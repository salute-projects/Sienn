using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SIENN.Domain.Abstraction;

namespace SIENN.Domain.Entities
{
    public class Category : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        public long Code { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Updated { get; set; }

        [JsonIgnore]
        public ICollection<ProductCategoryLink> Products { get; set; } = new List<ProductCategoryLink>();
    }
}