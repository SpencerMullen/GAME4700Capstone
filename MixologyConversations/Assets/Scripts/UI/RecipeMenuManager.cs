using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeMenuManager : MonoBehaviour
{
    public GameObject RecipeSlotPrefab; 
    public RecipeInventory Inventory; 
    public Recipe currentRecipe;
    public Recipe lockedRecipe;
 
    private Image recipeImage;
    private TextMeshProUGUI recipeName;
    private TextMeshProUGUI tagDescriptionText;
    private TextMeshProUGUI ingredientDescriptionText;

    void Awake() 
    {
        GameObject recipeDescription = this.gameObject.transform.Find("RecipeDescription").gameObject;
        GameObject topObject = recipeDescription.transform.Find("TopDescription").gameObject;
        recipeImage = topObject.transform.Find("Border").gameObject.transform.Find("ItemImage").GetComponent<Image>();
        recipeName = topObject.transform.Find("RecipeName").GetComponent<TextMeshProUGUI>();
        GameObject bottomObject = recipeDescription.transform.Find("BottomDescription").gameObject;
        tagDescriptionText = bottomObject.transform.Find("Tags").GetComponent<TextMeshProUGUI>();
        ingredientDescriptionText = bottomObject.transform.Find("Ingredients").GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Recipe r in Inventory.GetAllRecipes())
        {
            GameObject newSlot = Instantiate(RecipeSlotPrefab, transform.position, Quaternion.identity);
            RecipeSlot recipeSlot = newSlot.GetComponent<RecipeSlot>();
            if (r.isUnlocked())
            {
                recipeSlot.SetRecipe(r, this);
            }
            else 
            {
                recipeSlot.SetRecipe(lockedRecipe, this);
            }
            Transform correctParent = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0);
            newSlot.transform.SetParent(correctParent);
        }
    }

    public void updateCurrentRecipe(Recipe recipe) 
    {
        currentRecipe = recipe;
        recipeImage.sprite = currentRecipe.image;
        var tempColor = recipeImage.color;
        tempColor.a = 1f;
        recipeImage.color = tempColor;

        // Title 
        string recipeTitle = "<b>" + recipe.title + "</b>\n" + "<size=80%>" + recipe.getDescription();
        recipeName.text = recipeTitle;

        // Tags
        string tagsText = "<b>Tags</b>\n<size=80%>";
        foreach (string tag in currentRecipe.getTags())
        {
            tagsText += tag + "\n";
        }
        tagDescriptionText.text = tagsText;

        // Ingredients
        string ingredientsText = "<b>Ingredients</b>\n<size=80%>";
        foreach (Ingredient ingredient in currentRecipe.requiredIngredients)
        {
            ingredientsText += ingredient.ingredientName + "\n";
        }
        ingredientDescriptionText.text = ingredientsText;
    }
}
