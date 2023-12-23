using System.ComponentModel.DataAnnotations;

namespace GlobalScholar.ViewModel
{
    public class ExpenseTypeVm
    {
        public long Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
