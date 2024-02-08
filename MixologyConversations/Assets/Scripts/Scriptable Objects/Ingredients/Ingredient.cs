using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ingredient")]
public class Ingredient : ScriptableObject
{
    public string ingredientName;
    public string description;
    public float cost;
    public int rarity; // enum?

    [Tooltip("Reference to the prefab that is the in-scene ingredient for mixing/display during the day cycle")]
    public GameObject sprite;
    public Sprite image;

    // TODO: Effects and flavors - these likely should be a separate enum rather than just string, or maybe even their own classes
    public List<string> flavorNames;
    public List<string> effectNames;

    public List<Flavor> flavors;

    // TODO: We might need a function let GenerateCard() here that spawns and returns a new instance of the 'sprite' from above - should
    // that be in here, or should it be done all in a CardSpawner?

}
