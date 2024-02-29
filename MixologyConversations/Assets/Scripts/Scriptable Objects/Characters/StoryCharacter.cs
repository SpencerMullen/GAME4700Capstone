using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Story Customer", menuName = "Customers/Story Customer")]
public class StoryCharacter : Character
{
    public Sprite profilePic;
    public Ingredient storyIngredients;
    public string[] dialogueQueue;
    public int[] visitDays;
}
