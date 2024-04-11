using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;
    public Character[] characters;
    // Maybe Story Character fields 
    // public StoryCharacters[] storyCharacters;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void InitializeCharacters(Character[] newCharacters) 
    {
        characters = newCharacters;
    }

    public Character NextCharacter(int characterIndex) 
    {
        if (characterIndex >= 0 && characterIndex < characters.Length)
        {
            return characters[characterIndex];
        }
        
        return null;
    }

    public void CheckDrink(Recipe drink, Character character) 
    {
        // Something with Drink Evaluation
    }
}
