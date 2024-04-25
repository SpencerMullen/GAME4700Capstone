using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private UnityEngine.UI.Image portraitImage;
    [SerializeField] private TextMeshProUGUI nametagText;
    private Story currentStory;
    private bool isDialogueActive = false;

    private static DialogueManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("WARNING: Another instance of DialogueManager already exists.");
            // Destroy(gameObject);
        }
    }

    public static DialogueManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogWarning("WARNING: DialogueManager is null.");
                return null;
            }
            else
            {
                return instance;
            }
        }
    }

    public static bool Active
    {
        get
        {
            return instance.isDialogueActive;
        }
    }

    private void Start()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (!isDialogueActive)
        {
            return;
        }

        // Left mouse button to continue dialogue
        if (Input.GetMouseButtonDown(0) && LevelManager.Instance.currentGameState.Equals(GameState.WAIT_FOR_CLICK)) // TODO : Track internally if dialogue can be started
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, Sprite characterPortrait, string name)
    {
        // Enter the ink story using dialogue UI
        currentStory = new Story(inkJSON.text);
        isDialogueActive = true;
        dialoguePanel.SetActive(true);        

        // Set the character portrait and name
        portraitImage.sprite = characterPortrait;
        nametagText.text = name;

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        // Debug.Log("Exiting dialogue mode.");
        yield return new WaitForSeconds(0.2f);
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        LevelManager.Instance.DialogueComplete();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
}
