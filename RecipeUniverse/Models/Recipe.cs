using Recipes.Models.ViewModels;
using RecipeUniverse.Areas.Identity.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeUniverse.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Recipe Name")]
        public string RecipeName { get; set; }
        [Required]
        [DisplayName("Ingredients")]
        public string RecipeIngredients { get; set; }
        [Required]
        [DisplayName("Description")]
        public string RecipeDescription { get; set; }

        [DisplayName("Image Url")]
        public string? ImageUrl { get; set; } = string.Empty;
        public string? OwningUserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<RecipeLikes>? Likes { get; set; } = new List<RecipeLikes>();
        public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();
        [NotMapped]
        public bool IsLiked { get; set; }

        [Required]
        public Level Level { get; set; }

        [Required]
        [DisplayName("Total Calories")]
        public int? TotalCalories { get; set; }

        [Required]
        [DisplayName("People Count")]
        public int? PeopleCount { get; set; }
        [Required]
        [DisplayName("Cooking Duration")]
        public string CookingDuration { get; set; }
        [RequiredForCreate(ErrorMessage = "Please select an image for the recipe.")]
        [DisplayName("Image of the Recipe")]
        [NotMapped]
        public IFormFile? File { get; set; }

    }
}
