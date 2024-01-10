using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeUniverse.Areas.Identity.Data;
using RecipeUniverse.Data.Repository.IRepository;
using RecipeUniverse.Data.Services;
using RecipeUniverse.Models;
using System.Diagnostics;

namespace RecipeUniverse.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IRecipeService _recipeService;
        private readonly IUserRecipeLikeService _userRecipeLikeService;
        private readonly IUserRecipeCommentService _userRecipeCommentService;

        public HomeController(IUserRecipeCommentService userRecipeCommentService, IUnitOfWork unityOfWork, UserManager<User> userManager, IRecipeService recipeService, IUserRecipeLikeService userRecipLikeService)
        {
            _userManager = userManager;
            _recipeService = recipeService;
            _userRecipeLikeService = userRecipLikeService;
            _userRecipeCommentService = userRecipeCommentService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var listOfRecipes = await _recipeService.GetAllRecipesAsync();
            return View(listOfRecipes);
        }

        public async Task<IActionResult> Details(int? recipeId)
        {

            var recipe = await _recipeService.GetRecipeByIdAsync(recipeId);
            recipe.Likes = await _userRecipeLikeService.GetLikesByRecipeIdAsync(recipeId);
            recipe.Comments = await _userRecipeCommentService.GetCommentsByRecipeIdAsync(recipeId);
            var user = await _userManager.GetUserAsync(User);
            if (user is null)
            {
                return NotFound();
            }
            return View(recipe);
        }


        public async Task<IActionResult> ManageLikesAsync(int recipeId)
        {
            var user = await _userManager.GetUserAsync(User);
            var recipe = await _recipeService.GetRecipeByIdAsync(recipeId);
            var recipeUserLike = await _userRecipeLikeService.GetLikeByUserRecipeAsync(user.Id, recipeId);
            if (recipeUserLike is not null)
            {
                await _userRecipeLikeService.DeleteLikeAsync(recipeUserLike.RecipeId);
                return RedirectToAction("Details", new { recipeId });
            }
            var userRecipeLike = new RecipeLikes
            {
                RecipeId = recipeId,
                Recipe = recipe,
                UserId = user.Id,
                User = user
            };
            _userRecipeLikeService.AddLike(userRecipeLike);
            return RedirectToAction("Details", new { recipeId });
        }


        public async Task<IActionResult> AddComment(int recipeId, string commentText)
        {

            if (string.IsNullOrWhiteSpace(commentText))
            {
                TempData["error"] = "Please enter a comment before submitting.";
                return RedirectToAction("Details", new { recipeId });
            }

            var user = await _userManager.GetUserAsync(User);
            var recipe = await _recipeService.GetRecipeByIdAsync(recipeId);
            var newComment = new Comment()
            {
                User = user,
                UserId = user.Id,
                Recipe = recipe,
                RecipeId = recipeId,
                TheComment = commentText
            };

            _userRecipeCommentService.AddComment(newComment);
            TempData["success"] = "Comment added successfully.";
            return RedirectToAction("Details", new { recipeId });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}