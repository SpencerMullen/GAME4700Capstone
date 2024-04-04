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
    public string id;

    [Tooltip("Reference to the prefab that is the in-scene ingredient for mixing/display during the day cycle")]
    // public GameObject sprite;
    public Sprite sprite;

    // TODO: Effects and flavors - these likely should be a separate enum rather than just string, or maybe even their own classes
    public List<string> flavorNames;
    public List<string> effectNames;

}
