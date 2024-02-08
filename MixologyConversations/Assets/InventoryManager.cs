using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Dictionary of card Ids and ingredients
    private Dictionary<string, Ingredient> mixingCardSet;
    /* Can delete late, using for testing rn*/
    private List<string> mixingCardNames;

    [SerializeField] private PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * TODO: 
     * - when card is drawn, add it to the 'holding' inventory and awary from the 'permanent' inventory
     */


    public void addToMixingCards(Ingredient i)
    {
        bool ingredientAvailable = playerInventory.takeIngredient(i);
        if (ingredientAvailable)
        {
            mixingCardNames.Add(i.ingredientName);
        }

        Debug.Log(mixingCardNames);
    }
}
