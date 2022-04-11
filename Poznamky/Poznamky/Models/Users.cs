using System.ComponentModel.DataAnnotations;

namespace Poznamky.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = String.Empty;

        [Required]
        public string Mail { get; set; } = String.Empty;
    }
}