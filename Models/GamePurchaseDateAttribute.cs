using System.ComponentModel.DataAnnotations;

namespace assignment1.Models
{
    public class GamePurchaseDateAttribute : ValidationAttribute
    {
        public string GetErrorMessage()
        {
            return "You can not pick a future date";
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var game = (Game)validationContext.ObjectInstance;
            
            if (game.PurchaseDate <= DateTime.Today)
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
