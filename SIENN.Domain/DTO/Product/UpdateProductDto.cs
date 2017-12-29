using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SIENN.Domain.DTO.Product
{
    public class UpdateProductDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public long Code { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public DateTimeOffset DeliveryDate { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        [Required]
        public int UnitId { get; set; }

        [Required]
        public IEnumerable<int> CategoryIds { get; set; }
    }
}
