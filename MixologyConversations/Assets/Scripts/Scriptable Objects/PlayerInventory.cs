using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    // TODO: not public
    [SerializeField] private List<Ingredient> allIngredients;

    /* List of ingredients with the amount in the inventory currently */
    private Dictionary<Ingredient, int> ingredients;


    /* Used for development, at least until we get a custom dictionary UI editor built in*/
    public void Initialize()
    {
        foreach (Ingredient i in allIngredients) {
            ingredients.Add(i, 10);
        }
    }

    public bool takeIngredient(Ingredient i)
    {
        int amount;
        ingredients.TryGetValue(i, out amount);
        if (amount > 0)
        {
            Debug.Log("Taking ingredient from inventory; Remaining: " + (amount - 1));
            ingredients[i] = amount - 1;
            return true;
        }
        else
        {
            Debug.Log("No more of these");
            return false;
        }
    }
}
