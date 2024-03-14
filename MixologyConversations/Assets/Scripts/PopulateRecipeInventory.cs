using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateRecipeInventory : MonoBehaviour
{
    public RecipeInventory recipeInventory;

    // Start is called before the first frame update
    void Start()
    {
        // TODO : This only needs to be run on game load, not every scene, but we are rushing so we will come back to this
        recipeInventory.generateRecipeMap();
    }
}
