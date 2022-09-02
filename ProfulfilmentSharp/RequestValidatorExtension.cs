using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ProfulfilmentSharp.Entities.Responses;

namespace ProfulfilmentSharp
{
    public static class RequestValidatorExtension
    {
        public static ValidatorResponse Validate<TSource>(this TSource instance)
        {
            var validatorResponse = new ValidatorResponse();
            var context = new ValidationContext(instance, null, null);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(instance, context, results))
            {
                var errorBuilder = new StringBuilder();
                foreach (var validationResult in results) errorBuilder.Append(validationResult.ErrorMessage + ",");
                validatorResponse.ValidationErrors = errorBuilder.ToString();
                errorBuilder.Clear();
                return validatorResponse;
            }

            validatorResponse.IsValidRequest = true;
            return validatorResponse;
        }
    }
}