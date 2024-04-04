using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    [SerializeField] private List<Ingredient> allIngredients = new List<Ingredient>();


    public Ingredient GetIngredient(string id)
    {
        foreach (Ingredient i in allIngredients)
        {
            if (i.id == id)
            {
                return i;
            }
        }
        return null;
    }
    /* List of ingredients with the amount in the inventory currently */
    // private Dictionary<Ingredient, int> ingredients = new Dictionary<Ingredient, int>();


    /* Used for development, at least until we get a custom dictionary UI editor built in*/
    /* public void Initialize()
    {
        Debug.Log(allIngredients);
        Debug.Log(allIngredients.Count);
        foreach (Ingredient i in allIngredients) {
            Debug.Log(i.name);
            ingredients.TryAdd(i, 10);
        }
    }*/

    /*public bool takeIngredient(Ingredient i)
    {
        ingredients.TryGetValue(i, out int amount);
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
    }*/
}
