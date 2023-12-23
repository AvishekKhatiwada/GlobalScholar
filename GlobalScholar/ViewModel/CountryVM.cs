
using System.ComponentModel.DataAnnotations;

namespace GlobalScholar.ViewModel
{
    public class CountryVM
    {
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
