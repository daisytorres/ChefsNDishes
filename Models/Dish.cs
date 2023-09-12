#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ChefsNDishes.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required]
    public string DishName { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Calories must be greater than 0.")]
    public int Calories { get; set; }

    [Required]
    public int Tastiness { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //foreign key
    public int ChefId {get;set;}

    //navigation prop
    public Chef? Creator { get; set; }

}
