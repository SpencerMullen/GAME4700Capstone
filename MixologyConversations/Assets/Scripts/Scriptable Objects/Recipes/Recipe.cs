using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    [SerializeField] private List<Ingredient> requiredIngredients;
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private List<string> tags;
}
