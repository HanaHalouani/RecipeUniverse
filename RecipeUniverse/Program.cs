using Microsoft.EntityFrameworkCore;
using RecipeUniverse.Areas.Identity.Data;
using RecipeUniverse.Data.Repository;
using RecipeUniverse.Data.Repository.IRepository;
using RecipeUniverse.Data.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserRecipeLikeService, UserRecipeLikeService>();
builder.Services.AddScoped<IUserRecipeCommentService, UserRecipeCommentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRecipeCommentRepository, UserRecipeCommentRepository>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var connectionString = builder.Configuration.GetConnectionString("RecipeUniverseContextConnection") ?? throw new InvalidOperationException("Connection string 'RecipeUniverseContextConnection' not found.");

builder.Services.AddDbContext<RecipeUniverseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<RecipeUniverseContext>();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
