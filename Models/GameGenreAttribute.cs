using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class GameGenreAttribute : ValidationAttribute
    {
        public string GetErrorMessage()
        {
            return "Genre can be either FPS, Horror, or Adventure";
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var game = (Game)validationContext.ObjectInstance;
            if (game.Genre == "horror" ||
                game.Genre == "fps" ||
                game.Genre == "adventure")
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
