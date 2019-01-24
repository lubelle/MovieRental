using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customerDto = (CustomerDto)validationContext.ObjectInstance;

            if (customerDto.MembershipTypeId == 0 ||
                customerDto.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customerDto.BirthDate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customerDto.BirthDate.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on membership.");
        }
    }
}