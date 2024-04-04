using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : ScriptableObject
{
    public string           levelName;
    public Character[]      characters;
    public Ingredient       unlockedIngredient;
}
