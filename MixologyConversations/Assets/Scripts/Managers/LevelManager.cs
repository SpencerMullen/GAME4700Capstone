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

    private void InitializeLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levels.Length)
        {
            characterManager.InitializeCharacters(levels[levelIndex].characters);
            // currentCharacter = characterManager.NextCharacter();
        }
    }

    // private void HandleNextCustomer()
    // {
    //     currentCharacterIndex += 1;
    //     currentCharacter = characterManager.NextCharacter();
    //     if (currentCharacter == null)
    //     {
    //         HandleLevelEnding(); 
    //     }
    // }

    private void HandleLevelEnding()
    {
        // unlockedIngredients 
        // Load Close Shop Scene or Any other scene we would like. 
    }

}
