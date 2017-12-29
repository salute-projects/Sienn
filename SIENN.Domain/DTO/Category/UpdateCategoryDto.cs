using System.ComponentModel.DataAnnotations;

namespace SIENN.Domain.DTO.Category
{
    public class UpdateCategoryDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public long Code { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
    }
}
