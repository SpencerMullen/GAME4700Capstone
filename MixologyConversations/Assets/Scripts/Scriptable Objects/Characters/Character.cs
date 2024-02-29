using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate float DrinkEvaluator(Recipe recipe);

[CreateAssetMenu(fileName = "New Customer", menuName = "Customers/Regular Customer")]
public class Character : ScriptableObject
{
    public string characterName;
    public string characterDescription;
    public string drinkOrderPrompt;
    public DrinkEvaluator satisfactoryDrinkRequirements;
}
