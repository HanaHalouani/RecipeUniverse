using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeUniverse.Models;

namespace RecipeUniverse.Areas.Identity.Data;

public class RecipeUniverseContext : IdentityDbContext<User>
{
    public RecipeUniverseContext(DbContextOptions<RecipeUniverseContext> options)
        : base(options)
    {
    }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeLikes> Likes { get; set; }
    public DbSet<Comment> Comments { get; set; }

}
