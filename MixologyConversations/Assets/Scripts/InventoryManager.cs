using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Dictionary of card Ids and ingredients
    private Dictionary<string, Ingredient> mixingCardSet = new Dictionary<string, Ingredient>();

    /* Can delete late, using for testing rn */
    private List<string> mixingCardNames = new List<string>();

    [SerializeField] private PlayerInventory playerInventory;

    void Start()
    {
        // playerInventory.Initialize();
    }
    /* 
     * TODO: 
     * - when card is drawn, add it to the 'holding' inventory and awary from the 'permanent' inventory
     */


    /*public void addToMixingCards(Ingredient i)
    {
        bool ingredientAvailable = playerInventory.takeIngredient(i);
        if (ingredientAvailable)
        {
            mixingCardNames.Add(i.ingredientName);
        }

        Debug.Log(mixingCardNames.Count);
    }*/
}
