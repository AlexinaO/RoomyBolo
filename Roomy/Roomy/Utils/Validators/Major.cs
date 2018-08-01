using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Roomy.Utils.Validators
{
    /// <summary>
    /// Valide l'age minimum
    /// </summary>
    public class Major : ValidationAttribute
    {
        public string Pays { get; set; }

        private readonly int year;

        public Major(int year)
        {
            this.year = year;
        }
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            if(value is DateTime)
            {
                return (DateTime)value <= DateTime.Now.AddYears(-this.year);
            }
            return false;
        }

        /*protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ((User)validationContext.ObjectInstance)
            return base.IsValid(value, validationContext);
        }*/

        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessageString, name, this.year, this.Pays);
            //return base.FormatErrorMessage(name);
        }
    }
}