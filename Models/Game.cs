using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class Game
    {
        public int GameId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Developer { get; set; }
        [Required]
        [GameGenreAttribute]
        public string? Genre { get; set; }
        [Required]
        [GameReleaseYearAttribute]
        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Purchase Date")]
        [GamePurchaseDateAttribute]
        public DateTime? PurchaseDate { get; set; }
        [Range(1,100)]
        public int? Rating { get; set; }
    }
}
