using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIENN.Domain.DTO.ProductType
{
    public class UpdateProductTypeDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public long Code { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
    }
}
