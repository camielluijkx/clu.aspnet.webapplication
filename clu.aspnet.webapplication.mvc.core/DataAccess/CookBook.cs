using System.Collections.Generic;
using clu.aspnet.webapplication.mvc.core.Models;

namespace clu.aspnet.webapplication.mvc.core.DataAccess
{
    public class CookBook : ICookBook
    {
        public List<Recipe> GetAllRecipes()
        {
            throw new System.NotImplementedException();
        }

        public Recipe GetRecipe(int recipeId)
        {
            throw new System.NotImplementedException();
        }

        public void AddRecipe(Recipe recipe)
        {
            throw new System.NotImplementedException();
        }
    }
}