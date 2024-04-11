using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public string description;
    public string dialogue;
    public string id;

    [Tooltip("Reference to the prefab that is the in-scene character for mixing/display during the day cycle")]
    public GameObject sprite;
    public Sprite image;

    // Some Evaluation System Object? 
    // public Dictionary<Rating, []Recipe> drinkEvaluation;
}
