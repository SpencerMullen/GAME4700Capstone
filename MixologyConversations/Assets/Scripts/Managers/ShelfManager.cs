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
    [SerializeField]
    private GameObject leftArrow;
    [SerializeField]
    private GameObject rightArrow;
    // Page number
    private int page = 0;

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

        // Clear shelf
        ClearShelf();

        // Initial basic ingredients
        InitialIngredients();

        // Populate shelf
        page = 0;
        PopulateShelf(page);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there are more ingredients to the right
        if((page + 1) * 9 < unlocked.Count) {
            rightArrow.SetActive(true);
        } else {
            rightArrow.SetActive(false);
        }

        // Check if there are more ingredients to the left
        if(page > 0) {
            leftArrow.SetActive(true);
        } else {
            leftArrow.SetActive(false);
        }
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

    // Populate the shelf given the page number
    // Starting at 0 (the first 9 ingredients) and incrementing by 9
    public void PopulateShelf(int page) {
        ClearShelf();
        for(int i = page * 9; i < (page + 1) * 9; i++) {
            if(i < unlocked.Count) {
                // Debug.Log("Populating ingredient: " + unlocked[i].name + " | " + i);
                PopulateIngredient(shelfSpots[i % 9], unlocked[i]);
            }
        }
    }

    // Go to the page to the left
    public void GoLeft() {
        Debug.Log("Going left");
        if(page > 0) {
            page--;
            PopulateShelf(page);
        }
    }

    // Go to the page to the right
    public void GoRight() {
        Debug.Log("Going right");
        if((page + 1) * 9 < unlocked.Count) {
            page++;
            PopulateShelf(page);
        }
    }

    // Clear the shelf
    public void ClearShelf() {
        foreach(Transform spot in shelfSpots) {
            foreach(Transform child in spot) {
                Destroy(child.gameObject);
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
        // Set the ingredient tooltip equal to the ingredient name, next line description, last line tags
        spawned.GetComponent<HoverTooltip>().SetTooltip(ingredient.name + "\n" + ingredient.description + "\nTags: " + string.Join(", ", ingredient.tags));
    }
}
