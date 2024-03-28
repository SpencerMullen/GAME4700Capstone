using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private MixingInventoryManager mixingInventoryManager;
    [SerializeField] private CharacterManager       characterManager;
    [SerializeField] private DialogueManager        dialogueManager;
    [SerializeField] private Level[]                levels;

    [SerializeField] private int currentLevelIndex = 0;
    private int currentCharacterIndex = 0;
    private Character currentCharacter;
    private Recipe currentRecipe;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        InitializeLevel(currentLevelIndex);
    }

    void Update()
    {
        // While Level is Playing Do these things
        // - Allow Dialogue from currentCharacter (clicking on currentCharacter) And stop scene to play dialogue
        // - Mixing and Giving Recipe to Character 
        // - Once Given - Return a drinkRating and display the rating or satsification with dialogue or some other form
        // - Once the day is over, use HandleNextCustomer
        // 
    }

    private void InitializeLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levels.Length)
        {
            characterManager.InitializeCharacters(levels[levelIndex].characters);
            currentCharacter = characterManager.NextCharacter(currentCharacterIndex);
        }
    }

    private void HandleNextCustomer(int characterIndex)
    {
        currentCharacterIndex += 1;
        currentCharacter = characterManager.NextCharacter(currentCharacterIndex);
        if (currentCharacter == null)
        {
            HandleLevelEnding(); 
        }
    }

    private void HandleLevelEnding()
    {
        // unlockedIngredients 
        // Load Close Shop Scene or Any other scene we would like. 
    }

}
