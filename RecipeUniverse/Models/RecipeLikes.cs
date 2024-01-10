using RecipeUniverse.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace RecipeUniverse.Models
{
    public class RecipeLikes
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

    }
}