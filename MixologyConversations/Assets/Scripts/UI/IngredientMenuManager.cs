using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class IngredientMenuManager : MonoBehaviour
{
    public GameObject IngredientSlotPrefab; 
    public PlayerInventory Inventory; 
    public Ingredient currentIngredient;
    public Ingredient lockedIngredient;
 
    private GameObject ingredientDescription;
    private Image ingredientImage;
    private TextMeshProUGUI ingredients;
    private TextMeshProUGUI ingredientDescriptionText;

    void Awake() 
    {
        ingredientDescription = transform.Find("IngredientDescription").gameObject;
        GameObject topObject = ingredientDescription.transform.Find("TopDescription").gameObject;
        ingredientImage = topObject.transform.Find("Border").gameObject.transform.Find("ItemImage").GetComponent<Image>();
        ingredients = topObject.transform.Find("IngredientName").GetComponent<TextMeshProUGUI>();
        ingredientDescriptionText = ingredientDescription.transform.Find("Description").GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Ingredient i in Inventory.GetIngredientInventory())
        {
            GameObject newSlot = Instantiate(IngredientSlotPrefab, transform.position, Quaternion.identity);
            IngredientSlot ingredientSlot = newSlot.GetComponent<IngredientSlot>();
            if (i.isUnlocked())
            {
                ingredientSlot.SetIngredient(i, this);
            }
            else 
            {
                ingredientSlot.SetIngredient(lockedIngredient, this);
            }
            Transform correctParent = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0);
            newSlot.transform.SetParent(correctParent);
        }
    }

    public void updateCurrentIngredient(Ingredient ingredient) 
    {
        currentIngredient = ingredient;
        ingredientImage.sprite = currentIngredient.sprite;
        var tempColor = ingredientImage.color;
        tempColor.a = 1f;
        ingredientImage.color = tempColor;
        ingredientDescriptionText.SetText(currentIngredient.description);

        // // Flavors
        // string flavorsText = "Flavors: ";
        // foreach (string flavor in currentIngredient.flavorNames)
        // {
        //     flavorsText += flavor + ", ";
        // }
        // flavorsText = flavorsText.TrimEnd(',', ' ');

        // // Effects
        // string effectText = "Effects: ";
        // foreach (string effect in currentIngredient.effectNames)
        // {
        //     effectText += effect + ", ";
        // }
        // effectText = effectText.TrimEnd(',', ' ');
        // string ingredientTags = flavorsText + '\n' + effectText;
        // ingredients.text = ingredientTags;
    }
}
