using System;
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

    private GameState currentGameState;


    /** Events **/
    public event Action OnDialogueComplete;
    public event Action<GameState> OnGameStateChange;

    public void DialogueComplete()
    {
        if (OnDialogueComplete != null) OnDialogueComplete();
    }

    public void GameStateChange(GameState newGameState)
    {
        currentGameState = newGameState;
        if (OnGameStateChange != null) OnGameStateChange(newGameState);
    }

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
        currentGameState = GameState.WAIT_FOR_CUSTOMER;
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
