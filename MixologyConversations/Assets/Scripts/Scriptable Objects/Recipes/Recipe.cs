using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    // TODO: This should actually be a 2d array or list of Ingredient Sets to allow for multiple ways to create the same recipe
    public List<Ingredient> requiredIngredients;
    public string title;
    public Sprite image;
    [SerializeField] private string description;
    [SerializeField] private List<string> tags;
    public bool isDiscovered;

    public bool isUnlocked()
    {
        return isDiscovered;
    }

    public string getDescription()
    {
        return description;
    }

    public List<string> getTags()
    {
        return tags;
    }
}
