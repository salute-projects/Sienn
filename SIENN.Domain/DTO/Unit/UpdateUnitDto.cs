using System.ComponentModel.DataAnnotations;

namespace SIENN.Domain.DTO.Unit
{
    public class UpdateUnitDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public long Code { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
    }
}
