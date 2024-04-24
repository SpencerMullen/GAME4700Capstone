using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
    [SerializeField] private Ingredient ingredient;
    [SerializeField] private Image      ingredientImage;
    [SerializeField] private GameObject selectedPanel;
    
    public IngredientMenuManager ingredientMenuManager;

    void Awake()
    {
        ingredientImage = transform.Find("ItemImage").gameObject.GetComponent<Image>();
        selectedPanel = transform.Find("SelectedSlot").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        ingredientImage.sprite = ingredient.sprite;
    }

    // Method to set the ingredient for this slot
    public void SetIngredient(Ingredient newIngredient, IngredientMenuManager manager)
    {
        ingredient = newIngredient;
        ingredientImage.sprite = ingredient.sprite;
        ingredientMenuManager = manager;

    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    // Method called when the slot is clicked
    public void OnSlotClicked()
    {
        Debug.Log("Slot clicked! Ingredient: " + ingredient.name);
        
        // Add your click handling logic here
        if (ingredientMenuManager != null)
        {
            ingredientMenuManager.updateCurrentIngredient(ingredient);
        }
    }
}
