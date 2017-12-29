using System.ComponentModel.DataAnnotations;

namespace SIENN.Domain.DTO.ProductType
{
    public class AddProductTypeDto
    {
        [Required]
        public long Code { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
    }
}
