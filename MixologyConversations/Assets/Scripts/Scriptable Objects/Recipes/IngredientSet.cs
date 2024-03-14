using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class IngredientSet
{
    private List<Ingredient> ingredients;

    // In order to provide easy hashing for key searches in a dictionary,
    // an ingredient set will have an id that is the ids of the sorted ingredients concatenated.
    // i.e. '1-12-4' or 'coffee-milk-tea'
    public string id { get; }
    
    public IngredientSet(List<Ingredient> _ingredients)
    {
        ingredients = _ingredients;
        id = generateId();
    }

    public string generateId()
    {
        List<string> ingredientIds = ingredients.Select(ingredient => ingredient.id).ToList();
        ingredientIds.Sort();
        return string.Join("-", ingredientIds);
    }
}
