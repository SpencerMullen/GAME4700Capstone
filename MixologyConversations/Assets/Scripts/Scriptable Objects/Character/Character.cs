using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public string description;
    public string id;
    public string nameTag;
    public TextAsset dialogue;

    [Tooltip("Reference to the prefab that is the in-scene character for mixing/display during the day cycle")]
    public Sprite characterImage;
    public Sprite characterPortrait;

    public List<Recipe> threeStarDrinks;
    public List<Recipe> twoStarDrinks;
    public List<Recipe> oneStarDrinks;

    public DrinkCriteria orderCritera;


    public void initializeDrinkCritera()
    {
        orderCritera.populateFromCharacter(this);
    }

    public int getOrderRating(Recipe drinkServed)
    {
        return orderCritera.GetRating(drinkServed);
    }
}
