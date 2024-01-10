using Microsoft.AspNetCore.Identity;
using RecipeUniverse.Models;

namespace RecipeUniverse.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    public List<Recipe> Recipes { get; set; }
    public ICollection<Comment> Comments { get; set; }
}

