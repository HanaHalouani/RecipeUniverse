using RecipeUniverse.Areas.Identity.Data;

namespace RecipeUniverse.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? TheComment { get; set; }
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
        public int RecipeId { get; set; }
        public virtual Recipe? Recipe { get; set; }

    }
}