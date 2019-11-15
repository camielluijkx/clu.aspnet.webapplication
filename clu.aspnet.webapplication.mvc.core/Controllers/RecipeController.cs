using clu.aspnet.webapplication.mvc.core.DataAccess;
using clu.aspnet.webapplication.mvc.core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        private ICookBook _cookbook;

        public RecipeController(ICookBook cookbook)
        {
            _cookbook = cookbook;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var recipes = _cookbook.GetAllRecipes();

            return View(recipes);
        }

        public IActionResult Get(int recipeId)
        {
            var recipe = _cookbook.GetRecipe(recipeId);

            return View(recipe);
        }

        public IActionResult AddRecipe(Recipe recipe)
        {
            _cookbook.AddRecipe(recipe);

            return View();
        }
    }
}