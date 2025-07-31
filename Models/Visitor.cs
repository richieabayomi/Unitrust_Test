using System.ComponentModel.DataAnnotations;

namespace Unitrust_Test.Models
{
    public class Visitor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string VisitPurpose { get; set; }

        public DateTime Created_at { get; set; } = DateTime.Now;
    }
}
