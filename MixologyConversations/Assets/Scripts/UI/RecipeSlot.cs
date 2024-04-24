using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RecipeSlot : MonoBehaviour
{
    [SerializeField] private Recipe     recipe;
    [SerializeField] private Image      recipeImage;
    [SerializeField] private GameObject selectedPanel;
    

    public RecipeMenuManager recipeMenuManager;

    void Awake()
    {
        recipeImage = transform.Find("ItemImage").gameObject.GetComponent<Image>();
        selectedPanel = transform.Find("SelectedSlot").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        recipeImage.sprite = recipe.image;
    }

    // Method to set the ingredient for this slot
    public void SetRecipe(Recipe newRecipe, RecipeMenuManager manager)
    {
        recipe = newRecipe;
        recipeImage.sprite = recipe.image;
        recipeMenuManager = manager;

    }

    // Method called when the slot is clicked
    public void OnSlotClicked()
    {
        Debug.Log("Slot clicked! Recipe: " + recipe.name);
        
        // Add your click handling logic here
        if (recipeMenuManager != null)
        {
            recipeMenuManager.updateCurrentRecipe(recipe);
        }
    }
}
