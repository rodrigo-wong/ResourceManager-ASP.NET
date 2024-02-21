using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class GameReleaseYearAttribute : ValidationAttribute
    {
        public string GetErrorMessage()
        {
            return "Game must be at least 3 years old";
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var game = (Game)validationContext.ObjectInstance;

            if (DateTime.Now.Year - game.ReleaseYear >= 3)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(GetErrorMessage());
            }
        }
    }
}
