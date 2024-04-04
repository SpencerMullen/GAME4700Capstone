using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpawnOnClick : MonoBehaviour
{

    [SerializeField] public MixingInventoryManager mixingManager;
    [SerializeField] public Ingredient ingredientData;

    // Start is called before the first frame update
    void Start()
    {
        if (mixingManager == null)
        {
            mixingManager = FindObjectOfType<MixingInventoryManager>();
        }

        // Debug.Log("original id: " + gameObject.GetInstanceID());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("Object pressed");
        // Populate ingredient in the mixing card table
        mixingManager.addIngredient(gameObject, ingredientData);

        // OR

        // Drag and drop ability, instantiate a 'draggable ingredient' prefab, call the 'populateIngredient' function?
    }

    public void SetIngredientData(Ingredient data)
    {
        ingredientData = data;
    }
}
