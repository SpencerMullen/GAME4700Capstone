using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RecipeSlot : MonoBehaviour
{
    [SerializeField] private Recipe     recipe;
    [SerializeField] private Image      recipeImage;
    [SerializeField] private GameObject selectedPanel;
    [SerializeField] public Recipe      lockedRecipe;
    

    public RecipeMenuManager recipeMenuManager;

    void Awake()
    {
        recipeImage = transform.Find("ItemImage").gameObject.GetComponent<Image>();
        selectedPanel = transform.Find("SelectedSlot").gameObject;
    }

    public void Update()
    {
        if (recipe.isUnlocked()) 
        {
            recipeImage.sprite = recipe.image;
        } 
        else 
        {
            recipeImage.sprite = lockedRecipe.image;
        }
    }

    // Method to set the ingredient for this slot
    public void SetRecipe(Recipe newRecipe, RecipeMenuManager manager)
    {
        recipe = newRecipe;
        recipeMenuManager = manager;
    }

    // Method called when the slot is clicked
    public void OnSlotClicked()
    {
        Debug.Log("Slot clicked! Recipe: " + recipe.name);
        
        // Add your click handling logic here
        if (recipeMenuManager != null)
        {
            if (recipe.isUnlocked()) 
            {
                recipeMenuManager.updateCurrentRecipe(recipe);
            } 
            else 
            {
                recipeMenuManager.updateCurrentRecipe(lockedRecipe);
            }
        }
    }
}
