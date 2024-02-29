using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingInventoryManager : MonoBehaviour { 

    [SerializeField] private MixingSpot[] mixingSpots;
    [SerializeField] private int maxIngredients;
    private int nextSpotIndex;

    // Start is called before the first frame update
    void Start()
    {
        nextSpotIndex = 0;
    }
    
    /*
     * Attempt to add an ingredient to the mixing table if there is an available slot.
     * Returns true if ingredient was added; false otherwise.
     */
    public bool addIngredient(GameObject ingredientPrefab)
    {
        Debug.Log("Passed object ID: " + ingredientPrefab.GetInstanceID());
        if (nextSpotIndex < maxIngredients)
        {
            // TODO: Move this logic into Mixing Spot class
            Transform spotParent = mixingSpots[nextSpotIndex].spotPos;
            GameObject spawned = Instantiate(ingredientPrefab, spotParent.position, spotParent.rotation, spotParent);
            mixingSpots[nextSpotIndex].currentIngredient = spawned;
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
                break;
            case "mix":
                Debug.Log("Ingredients Mixing");
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

    [System.Serializable]
    class MixingSpot
    {
        // TODO : getter, setter
        public Transform spotPos;
        public GameObject currentIngredient;

        public void removeIngredient()
        {
            if (currentIngredient != null)
            {
                Destroy(currentIngredient);
            }
        }
    }
}
