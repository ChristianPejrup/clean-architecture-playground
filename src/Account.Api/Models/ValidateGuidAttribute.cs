using System.ComponentModel.DataAnnotations;

namespace Account.Api.Models
{
    public class ValidateGuidAttribute : ValidationAttribute
    {
        static ValidationResult EmptyGuidMessage = new ValidationResult("Guid is an empty guid");

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is Guid guid) 
            {
                if(guid == Guid.Empty)
                {
                    return EmptyGuidMessage;
                }
                return ValidationResult.Success;
            }

            return new ValidationResult("value is not Guid");
        }
    }
}

