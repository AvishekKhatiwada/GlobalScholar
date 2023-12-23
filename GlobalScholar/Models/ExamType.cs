using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalScholar.Models
{
    [Table("ExamType")]
    public class ExamType
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
