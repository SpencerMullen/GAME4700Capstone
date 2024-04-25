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

    /** An optional character to populate the drink criteria from, rather than manually setting the recipe lists **/
    public Character character;


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

    /** Popualte the drink criteria lists from a character's order critera **/
    public void populateFromCharacter(Character character)
    {
        populateRatingMap(character.threeStarDrinks, 3);
        populateRatingMap(character.twoStarDrinks, 2);
        populateRatingMap(character.oneStarDrinks, 1);
    }

    public int GetRating(Recipe servedDrink)
    {
        // TODO: Add check for 'disgusting drink', score should be 0
        recipeRatingMap.TryGetValue(servedDrink.title, out int score);
        if (score == 0) score = 1;
        return score;
    }
}
