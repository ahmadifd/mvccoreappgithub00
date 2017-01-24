using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Infrastructure
{
    public class MaxWordsAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public virtual int MaxWords { get; set; }
        public MaxWordsAttribute(int maxWords)
        {
            MaxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return System.ComponentModel.DataAnnotations.ValidationResult.Success;
            if (value.ToString().Trim() == string.Empty)
                return System.ComponentModel.DataAnnotations.ValidationResult.Success;
            if (value.ToString().Length > MaxWords)
                return new System.ComponentModel.DataAnnotations.ValidationResult("اشکال");
            else
                return System.ComponentModel.DataAnnotations.ValidationResult.Success;

        }
    }
}