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

    private void Start()
    {
        LevelManager.Instance.OnGameStateChange += handleStateChange;
        LevelManager.Instance.OnDialogueComplete += OnDialogueComplete;
    }

    public void InitializeCharacters(Character[] newCharacters) 
    {
        characters = newCharacters;
        currentCharacterIndex = 0;
        foreach (Character character in characters)
        {
            Debug.Log("Character: " + character.characterName);
            character.initializeDrinkCritera();
        }

        this.NextCharacter();
    }

    public void NextCharacter() 
    {
        // TODO : Remove the old customer
        if (currentCharacterIndex >= 0 && currentCharacterIndex < characters.Length)
        {
            // TODO: Wait a random number of seconds before the new customer comes in? between 2 and 4 secs
            currentCharacter = characters[currentCharacterIndex];
            this.CreateCharacter();
            currentCharacterIndex += 1;
        }
    }

    public void CreateCharacter()
    {
        Vector3 newPosition = new Vector3(0, 0, 0); 
        Quaternion newRotation = Quaternion.identity;
        GameObject newCharacter = Instantiate(characterPrefab, newPosition, newRotation);         // TODO: Silhouette populate
        SpriteRenderer spriteRenderer = newCharacter.GetComponent<SpriteRenderer>();
        DialogueTrigger dialogueTrigger = newCharacter.GetComponent<DialogueTrigger>();
        spriteRenderer.sprite = currentCharacter.characterImage;
        dialogueTrigger.updateDialogueFields(currentCharacter.dialogue, currentCharacter.characterPortrait, currentCharacter.nameTag);


        LevelManager.Instance.GameStateChange(GameState.WAIT_FOR_CLICK);
    }

    public void handleStateChange(GameState newGameState)
    {
        // TODO : switch
        switch (newGameState)
        {
            case GameState.WAIT_FOR_CUSTOMER:
                NextCharacter();
                break;
            case GameState.POST_SERVE_DIALOGUE:
                PostServeDialogue();
                break;
            default:
                break;
        }
    }

    public void OnDialogueComplete()
    {
        // TODO: In the future, we might need to distinguish between post-serve and pre-serve (ordering) dialogue. That will happen here. For now, ignoring.
        LevelManager.Instance.GameStateChange(GameState.WAIT_FOR_MIXING_TABLE);
    }

    public void PostServeDialogue()
    {
        // TODO: For some characters, there might be post serving dialogue. For now, we are crunching and ignoring that
        LevelManager.Instance.GameStateChange(GameState.WAIT_FOR_CUSTOMER);
    }

    public int CheckDrink(Recipe drink) 
    {
        int rating = currentCharacter.getOrderRating(drink);
        Debug.Log(rating + " stars");
        return rating;
    }
}
