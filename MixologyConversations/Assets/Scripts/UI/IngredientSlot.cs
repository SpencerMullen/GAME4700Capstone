using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientSlot : MonoBehaviour
{
    [SerializeField] private Ingredient ingredient;
    [SerializeField] private Image      ingredientImage;
    [SerializeField] private GameObject selectedPanel;

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

    // Update is called once per frame
    void Update()
    {   
        
    }
}
