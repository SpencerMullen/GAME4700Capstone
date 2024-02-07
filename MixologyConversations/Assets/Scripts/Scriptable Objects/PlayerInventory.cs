using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Inventory")]
public class PlayerInventory : ScriptableObject
{
    /* List of ingredients with the amount in the inventory currently */
    Dictionary<Ingredient, int> ingredients;
}
