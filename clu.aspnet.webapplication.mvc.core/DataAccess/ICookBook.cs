using System.Collections.Generic;
using clu.aspnet.webapplication.mvc.core.Models;

namespace clu.aspnet.webapplication.mvc.core.DataAccess
{
    public interface ICookBook
    {
        List<Recipe> GetAllRecipes();

        Recipe GetRecipe(int recipeId);

        void AddRecipe(Recipe recipe);
    }
}