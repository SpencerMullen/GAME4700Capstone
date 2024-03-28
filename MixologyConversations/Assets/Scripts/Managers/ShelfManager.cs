using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    public static ShelfManager instance;

    [SerializeField]
    private GameObject ingredientPrefab;
    [SerializeField]
    private List<Transform> shelfSpots;

    [Header("Ingredients")]
    [SerializeField]
    private PlayerInventory playerInventory;
    [SerializeField]
    private List<Ingredient> unlocked;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Initial basic ingredients
        InitialIngredients();

        // Populate shelf
        PopulateShelf();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Add initial ingredients to the shelf
    public void InitialIngredients() {
        // Add coffee, milk, sugar, tea to unlocked
        AddToUnlocked("coffee");
        AddToUnlocked("milk");
        AddToUnlocked("sugar");
        AddToUnlocked("tea");
    }

    // Given an ingredient id, add to unlocked
    public void AddToUnlocked(string id) {
        if(playerInventory.GetIngredient(id) != null) {
            unlocked.Add(playerInventory.GetIngredient(id));
        } else {
            Debug.Log("Ingredient not found in player inventory: " + id);
        }
    }

    // Populate Shelf
    public void PopulateShelf() {
        for(int i = 0; i < shelfSpots.Count; i++) {
            if(i < unlocked.Count) {
                // Debug.Log("Populating ingredient: " + unlocked[i].name);
                PopulateIngredient(shelfSpots[i], unlocked[i]);
            }
        }
    }

    // Populate the ingredient in the shelf
    public void PopulateIngredient(Transform spot, Ingredient ingredient) {
        // Spawn prefab at spot
        GameObject spawned = Instantiate(ingredientPrefab, spot.position, spot.rotation, spot);
        // Set prefab image to match ingredient
        spawned.GetComponent<SpriteRenderer>().sprite = ingredient.sprite;
        // Set the ingredient data of spawned equal to the ingredient
        spawned.GetComponent<SpawnOnClick>().SetIngredientData(ingredient);
    }
}
