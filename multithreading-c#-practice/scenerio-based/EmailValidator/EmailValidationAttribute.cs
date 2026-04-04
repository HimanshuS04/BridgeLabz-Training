using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


    public class EmailValidationAttribute : ValidationAttribute
    {
        private const string pattern =
            @"^[a-zA-Z0-9._]+@[a-zA-Z.-]+\.[a-zA-Z]{2,6}$";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Email cannot be null.");

            if (!Regex.IsMatch(value.ToString(), pattern))
                return new ValidationResult("Invalid Email Format.");

            return ValidationResult.Success;
        }
    }

