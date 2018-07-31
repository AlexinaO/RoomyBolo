using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Roomy.Utils.Validators
{
    public class Check : ValidationAttribute
    {
        private string property;

        public Check(string property)
        {
            this.property = property;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(((bool)validationContext.ObjectInstance.GetType().GetProperty(this.property).GetValue(validationContext.ObjectInstance)) == true)
            {
                if (!string.IsNullOrWhiteSpace(value?.ToString()))
                    return ValidationResult.Success;
                else
                    return new ValidationResult(this.ErrorMessageString);
            }

            return ValidationResult.Success;
        }

    }
}