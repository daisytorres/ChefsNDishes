#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models;


public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [Required]
    [Display(Name = "First Name:")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name:")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Date of Birth")]
    [PastDate(ErrorMessage = "Date must be in the past")]
    public DateTime Birthday { get; set; }
    public int Age
    {
        get { return DateTime.Now.Year - Birthday.Year; }
    }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public List<Dish> Dishes { get; set;} = new(); //recommended to bring back empty list in case chef/user (one) does not have a many 
}



public class PastDateAttribute: ValidationAttribute
{
    protected override ValidationResult IsValid (object value, ValidationContext validationContext)
    {
        if (((DateTime)value) > DateTime.Now)
        {
            return new ValidationResult ("Date must be in the past");
        } else {
            return ValidationResult.Success;
        }
    }
}

