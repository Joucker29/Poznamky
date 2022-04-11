using System.ComponentModel.DataAnnotations;

namespace Poznamky.Models
{
    public class Poznamkyy
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        public string Text { get; set; } = string.Empty;

        [Required]
        public string Prezdivka { get; set; } = string.Empty;

    }
}
