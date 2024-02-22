using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/** A displayable ingredient for drink making */
public class IngredientCard : MonoBehaviour
{
    [Header("Text fields")]
    [SerializeField] private TextMeshPro titleText;
    [SerializeField] private TextMeshPro descriptionText;
    // [SerializeField] private TextMeshPro costText;

    [Header("Image(s)")]
    [SerializeField] private SpriteRenderer icon;
    [SerializeField] private GameObject iconObject; // TODO: can likely remove this

    [SerializeField] private Ingredient ingredient;

    [SerializeField] private InventoryManager inventoryManager;

    void Start()
    {
       if (inventoryManager == null)
        {
            inventoryManager = FindFirstObjectByType<InventoryManager>();
        }
    }

    /** Populate the card face details from the given Ingredient S.O. instance. */
    public void PopulateDetailsFrom(Ingredient _ingredient)
    {
        titleText.text = _ingredient.name;
        descriptionText.text = _ingredient.description;

        icon.sprite = _ingredient.image;
        ingredient = _ingredient;
    }

    void OnMouseDown()
    {
        Debug.Log(ingredient.name + " was clicked");
        inventoryManager.addToMixingCards(ingredient);
    }
}
