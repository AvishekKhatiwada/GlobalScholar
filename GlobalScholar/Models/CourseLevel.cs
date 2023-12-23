using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalScholar.Models
{
    [Table("CourseLevel")]
    public class CourseLevel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
