using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DrinkCriteria : MonoBehaviour
{
    // These are exposed just for easy setting in the editor; the actual searching is done via Dictionary
    public List<Recipe> threeStarRecipes = new List<Recipe>();
    public List<Recipe> twoStarRecipes = new List<Recipe>();
    public List<Recipe> oneStarRecipes = new List<Recipe>();

    /** A dictionary mapping the recipe id to the star score **/
    public Dictionary<string, int> recipeRatingMap = new Dictionary<string, int>();


    // Start is called before the first frame update
    void Start()
    {
        populateRatingMap(threeStarRecipes, 3);
        populateRatingMap(twoStarRecipes, 2);
        populateRatingMap(oneStarRecipes, 1);
    }

    private void populateRatingMap(List<Recipe> recipes, int score)
    {
        foreach (Recipe recipe in recipes)
        {
            recipeRatingMap.Add(recipe.title, score);
        }
    }

    public int GetRating(Recipe servedDrink)
    {
        int score = 0;
        recipeRatingMap.TryGetValue(servedDrink.title, out score);
        return score;
    }
}
