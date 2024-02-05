using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using aspnetapp.Constants;

namespace aspnetapp.Model.Dto;



public abstract class PatientAndOrUpdateDto : IValidatableObject
{
    
    //[Required(ErrorMessage = "{0} is a must have item")]
    public int Id { get; set; }
    
    public string Email { get; set; }
    
    //[Required(ErrorMessage = "{0} is a must have item")]
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    
    //[Required(ErrorMessage = "{0} is a must have item")]
    public string LastName { get; set; }
    
    public DateTime Dob { get; set; }
    public string Ssn { get; set; }
        
    public string Address { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string State { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
    
        if (FirstName == LastName)
        {
            yield return new ValidationResult("Last name and first name should be different", 
                new[] { nameof(LastName), nameof(FirstName) });
        }
        
        if (DateTime.Now.Subtract(Dob).TotalDays > ProjectConstants.MAX_LIFE_SPAN_IN_DAYS)
        {
            yield return new ValidationResult("DOB is too far awy", 
                new[] { nameof(Dob) });
        }
    }
}