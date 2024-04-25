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
    [SerializeField]
    private GameObject dimBackground;
    [SerializeField]
    private GameObject shelf;
    [SerializeField] private GameObject RatingScreenStars;

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

    }

    // Start is called before the first frame update
    void Start()
    {
        // Register for events
        LevelManager.Instance.OnGameStateChange += handleGameStateChange;
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
                // shelfPrompter.SetActive(true);
                LevelManager.Instance.GameStateChange(GameState.IN_MIXING_TABLE);
                break;
            case GameState.IN_MIXING_TABLE:
                dimBackground.SetActive(true);
                shelf.SetActive(true);
                break;
            case GameState.RATING_SCREEN:
                Debug.Log("UI Manager Rating Screen");
                shelf.SetActive(false);
                dimBackground.SetActive(true);
                RatingScreenStars.SetActive(true);
                break;
            case GameState.WAIT_FOR_CUSTOMER:
                RatingScreenStars.SetActive(false);
                dimBackground.SetActive(false);
                break;
            default:
                shelfPrompter.SetActive(false);
                //dimBackground.SetActive(false);
                shelf.SetActive(false);
                //RatingScreenStars.SetActive(false);
                break;
        }
    }
}
