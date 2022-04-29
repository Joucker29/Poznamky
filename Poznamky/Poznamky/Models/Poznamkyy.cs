using System.ComponentModel.DataAnnotations;

namespace Poznamky.Models
{
    public class Poznamkyy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nadpis { get; set; } = String.Empty;

        [Required]
        public string Text { get; set; } = String.Empty;

        [Required]
        public DateTime CasPridani { get; set; }
        
        [Required]
        public bool JeDulezita { get; set; }

        [Required]
        public string Owner { get; set; } = String.Empty;
    }
}
