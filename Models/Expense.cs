using System.ComponentModel.DataAnnotations;

namespace AppointmentApplication.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1.00, 4000, ErrorMessage ="Amount must be greater than 0 and less than 4000")]
        public float Amount { get; set; }
    }
}