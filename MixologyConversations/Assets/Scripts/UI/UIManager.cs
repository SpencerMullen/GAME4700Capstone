using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public bool isUIActive = false;

    // UI Panels to check if active
    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    private GameObject recipeBookPanel;
    [SerializeField]
    private GameObject notepadPanel;

    // Shelf Prompter button
    [SerializeField]
    private GameObject shelfPrompter;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("WARNING: Another instance of UIManager already exists.");
        }

        // Register for events
        LevelManager.Instance.OnGameStateChange += handleGameStateChange;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if any UI is active
        if(dialoguePanel.activeSelf)
        // || recipeBookPanel.activeSelf || notepadPanel.activeSelf)
        {
            isUIActive = true;
        }
        else
        {
            isUIActive = false;
        }
    }

    private void handleGameStateChange(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.WAIT_FOR_MIXING_TABLE:
                shelfPrompter.SetActive(true);
                break;
            default:
                shelfPrompter.SetActive(false);
                break;
        }
    }
}
