using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;
    public Character[] characters;
    public Character currentCharacter;
    public GameObject characterPrefab; 
    // public Transform characterSpawnPoint;
 
    private int currentCharacterIndex = 0;
    SpriteRenderer spriteRenderer;
    DialogueTrigger dialogueTrigger;


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
        currentCharacterIndex = 0;
        this.NextCharacter();
    }

    public void NextCharacter() 
    {
        if (currentCharacterIndex >= 0 && currentCharacterIndex < characters.Length)
        {
            currentCharacter = characters[currentCharacterIndex];
            this.CreateCharacter();
            currentCharacterIndex += 1;
        }
    }

    public void CreateCharacter()
    {
        Vector3 newPosition = new Vector3(0, 0, 0); 
        Quaternion newRotation = Quaternion.identity;
        GameObject newCharacter = Instantiate(characterPrefab, newPosition, newRotation);
        SpriteRenderer spriteRenderer = newCharacter.GetComponent<SpriteRenderer>();
        DialogueTrigger dialogueTrigger = newCharacter.GetComponent<DialogueTrigger>();
        spriteRenderer.sprite = currentCharacter.characterImage;
        dialogueTrigger.updateDialogueFields(currentCharacter.dialogue, currentCharacter.characterPortrait, currentCharacter.nameTag);
    }

    public void CheckDrink(Recipe drink, Character character) 
    {
        // Something with Drink Evaluation
    }
}
