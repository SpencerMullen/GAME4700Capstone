using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MixingInventoryManager : MonoBehaviour { 

    [SerializeField] private MixingSpot[] mixingSpots;
    [SerializeField] private int maxIngredients;
    private int nextSpotIndex;

    [SerializeField] private RecipeInventory recipeInventory;

    [SerializeField] private GameObject drinkSpawn;
    private SpriteRenderer drinkSprite;

    // Start is called before the first frame update
    void Start()
    {
        nextSpotIndex = 0;
        drinkSpawn.SetActive(false);
        drinkSprite = drinkSpawn.GetComponent<SpriteRenderer>();
    }

    /*
     * Attempt to add an ingredient to the mixing table if there is an available slot.
     * Returns true if ingredient was added; false otherwise.
     */
    public bool addIngredient(GameObject ingredientPrefab, Ingredient ingredientData)
    {
        Debug.Log("Passed object ID: " + ingredientPrefab.GetInstanceID());
        if (nextSpotIndex < maxIngredients)
        {
            // TODO: Move this logic into Mixing Spot class, check for already filled game object slot
            Transform spotParent = mixingSpots[nextSpotIndex].spotPos;
            GameObject spawned = Instantiate(ingredientPrefab, spotParent.position, spotParent.rotation, spotParent);
            mixingSpots[nextSpotIndex].currentIngredient = spawned;
            mixingSpots[nextSpotIndex].currentIngredientData = ingredientData;

            nextSpotIndex += 1;
            return true;
        } else
        {
            Debug.Log("Mixing slots full.");
            return false;
        }
    }

    // TODO: Replace with proper events
    public void handleMessage(string type)
    {
        switch (type)
        {
            case "clear":
                clearIngredients();
                clearDrinkSpawn();
                break;
            case "mix":
                Debug.Log("Ingredients Mixing");
                mixIngredients();
                // TODO : gather ingredients and call a recipe creator class to check if it makes a recipe
                break;
            default:
                break;
        }
    }

    void clearIngredients()
    {
        foreach (MixingSpot spot in mixingSpots)
        {
            spot.removeIngredient();
        }
        nextSpotIndex = 0;
        Debug.Log("Ingredients Cleared");
    }

    void clearDrinkSpawn()
    {
        drinkSpawn.SetActive(false);
    }

    void mixIngredients()
    {
        List<Ingredient> ingredients = mixingSpots.Select(spot => spot.currentIngredientData).Where(ingredient => ingredient != null).ToList();
        foreach (Ingredient ingredient in ingredients)
        {
            Debug.Log(ingredient.name);
        }

        Recipe createdRecipe = recipeInventory.getRecipeFromIngredients(ingredients);
        if (createdRecipe != null)
        {
            Debug.Log(createdRecipe.name);
            drinkSprite.sprite = createdRecipe.image;
            drinkSpawn.SetActive(true);
        } else
        {
            Debug.Log("No recipe can be created");
        }

        clearIngredients();

    }

    [System.Serializable]
    class MixingSpot
    {
        // TODO : getter, setter
        public Transform spotPos;
        public GameObject currentIngredient;
        public Ingredient currentIngredientData;

        public void removeIngredient()
        {
            if (currentIngredient != null)
            {
                Destroy(currentIngredient);
            }

            currentIngredientData = null;
        }
    }
}
