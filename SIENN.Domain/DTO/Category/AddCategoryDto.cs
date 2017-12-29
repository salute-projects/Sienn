using System.ComponentModel.DataAnnotations;

namespace SIENN.Domain.DTO.Category
{
    public class AddCategoryDto
    {
        [Required]
        public long Code { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
    }
}
