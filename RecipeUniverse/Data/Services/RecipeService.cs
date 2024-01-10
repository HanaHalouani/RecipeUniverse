using RecipeUniverse.Areas.Identity.Data;
using RecipeUniverse.Data.Repository.IRepository;
using RecipeUniverse.Models;

namespace RecipeUniverse.Data.Services;

public class RecipeService : IRecipeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public RecipeService(
        IUnitOfWork unitOfWork,
        IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));

    }

    public async Task<List<Recipe>> GetRecipesByUserAsync(string userId)
    {
        var recipeList = await _unitOfWork.RecipeRepository.GetAllByUserAsync(u => u.OwningUserId == userId);

        return recipeList.ToList();

    }

    private string SaveOrUpdateImage(Recipe recipeVm)
    {
        string wwwRootPath = _webHostEnvironment.WebRootPath;
        string fileName = Guid.NewGuid() + Path.GetExtension(recipeVm.File?.FileName);
        string recipeImageDirectory = Path.Combine(wwwRootPath, @"image\recipe");

        if (!string.IsNullOrEmpty(recipeVm.ImageUrl))
        {
            string oldRecipeImage = Path.Combine(wwwRootPath, recipeVm.ImageUrl.TrimStart('\\'));
            if (File.Exists(oldRecipeImage))
            {
                File.Delete(oldRecipeImage);
            }
        }
        using (var fileStream =
               new FileStream(Path.Combine(recipeImageDirectory, fileName), FileMode.Create))
        {
            recipeVm.File.CopyTo(fileStream);
        }
        return @"\image\recipe\" + fileName;
    }


    public void CreateRecipe(Recipe recipe, User user)
    {
        recipe.ImageUrl = SaveOrUpdateImage(recipe);
        recipe.OwningUserId = user.Id;
        recipe.User = user;
        _unitOfWork.RecipeRepository.Add(recipe);
        _unitOfWork.Save();
    }


    public async Task UpdateRecipeAsync(Recipe recipe)
    {
        if (recipe.File is not null)
        {
            recipe.ImageUrl = SaveOrUpdateImage(recipe);
        }
        _unitOfWork.RecipeRepository.Update(recipe);
        _unitOfWork.Save();
    }

    public void DeleteRecipeAsync(Recipe? recipe)
    {
        if (recipe == null)
            return;
        _unitOfWork.RecipeRepository.Delete(recipe);
        _unitOfWork.Save();
    }

    public async Task<List<Recipe>> GetAllRecipesAsync()
    {
        var recipeList = await _unitOfWork.RecipeRepository.GetAllAsync();
        return recipeList.ToList();
    }
    public async Task<Recipe> GetRecipeByIdAsync(int? recipeId)
    {
        var recipeNon = await _unitOfWork.RecipeRepository.GetAsync(r => r.Id == recipeId);
        return recipeNon;
    }

}