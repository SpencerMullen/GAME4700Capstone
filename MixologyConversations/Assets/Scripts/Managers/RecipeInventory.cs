using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipeInventory : ScriptableObject
{
    private List<Recipe> recipes;

    // A dictionary between the id for the ingredient set and the Recipe it creates
    private Dictionary<string, Recipe> recipeCreationMap;


    /*
     * To run on start. Populates the recipeCreationMap with the ingredient set id(s) for each recipe.
     */
    public void generateRecipeMap()
    {
        foreach (Recipe recipe in recipes)
        {
            string recipeKey = getIngredientSetId(recipe.requiredIngredients);
            recipeCreationMap[recipeKey] = recipe;
        }
    }

    public Recipe getRecipeFromIngredients(List<Ingredient> ingredients)
    {
        string ingredientSetId = getIngredientSetId(ingredients);

        Recipe recipe = null;
        recipeCreationMap.TryGetValue(ingredientSetId, out recipe);

        return recipe;
    }
    
    // TODO: This is duplicated from the IngredientSet class - we should choose which one to use.
    private string getIngredientSetId(List<Ingredient> ingredients)
    {
        List<string> ingredientIds = ingredients.Select(ingredient => ingredient.id).ToList();
        ingredientIds.Sort();
        return string.Join("-", ingredientIds);
    }
}
