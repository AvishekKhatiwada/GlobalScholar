using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalScholar.Models
{
    [Table("Country")]
    public class Country
    {
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
