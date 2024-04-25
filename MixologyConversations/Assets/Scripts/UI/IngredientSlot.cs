using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
    [SerializeField] private Ingredient ingredient;
    [SerializeField] private Image      ingredientImage;
    [SerializeField] private GameObject selectedPanel;
    [SerializeField] public  Ingredient lockedIngredient;
    
    public IngredientMenuManager ingredientMenuManager;

    void Awake()
    {
        ingredientImage = transform.Find("ItemImage").gameObject.GetComponent<Image>();
        selectedPanel = transform.Find("SelectedSlot").gameObject;
    }

    public void Update()
    {
        if (ingredient.isUnlocked()) 
        {
            ingredientImage.sprite = ingredient.sprite;
        } 
        else 
        {
            ingredientImage.sprite = lockedIngredient.sprite;
        }
    }

    // Method to set the ingredient for this slot
    public void SetIngredient(Ingredient newIngredient, IngredientMenuManager manager)
    {
        ingredient = newIngredient;
        ingredientMenuManager = manager;

    }

    // Method called when the slot is clicked
    public void OnSlotClicked()
    {
        Debug.Log("Slot clicked! Ingredient: " + ingredient.name);
        
        // Add your click handling logic here
        if (ingredientMenuManager != null)
        {
            if (ingredient.isUnlocked()) 
            {
                ingredientMenuManager.updateCurrentIngredient(ingredient);
            } 
            else 
            {
                ingredientMenuManager.updateCurrentIngredient(lockedIngredient);
            }
        }
    }
}
