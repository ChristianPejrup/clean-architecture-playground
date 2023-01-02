using System.ComponentModel.DataAnnotations;

namespace Account.Api.Models
{
    public class ValidateGuidAttribute : ValidationAttribute
    {
        static ValidationResult EmptyGuidMessage = new ValidationResult("Guid is an empty guid");

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        {
            if(value is Guid guid) 
            {
                if(guid == Guid.Empty)
                {
                    return EmptyGuidMessage;
                }
#pragma warning disable CS8603 // Possible null reference return.
                return ValidationResult.Success;
#pragma warning restore CS8603 // Possible null reference return.
            }

            return new ValidationResult("value is not Guid");
        }
    }
}

