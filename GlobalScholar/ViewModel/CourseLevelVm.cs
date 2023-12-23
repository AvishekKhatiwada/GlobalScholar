using System.ComponentModel.DataAnnotations;

namespace GlobalScholar.ViewModel
{
    public class CourseLevelVm
    {
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
