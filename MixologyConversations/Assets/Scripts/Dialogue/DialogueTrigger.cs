using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private Sprite characterPortrait;
    [SerializeField] private string nametag;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !DialogueManager.Active && LevelManager.Instance.currentGameState.Equals(GameState.WAIT_FOR_CLICK))
        {
            StartCoroutine(TriggerDialogue());
        }
    }

    private IEnumerator TriggerDialogue()
    {
        yield return new WaitForSeconds(0.2f);
        if(DialogueManager.Instance) {
            DialogueManager.Instance.EnterDialogueMode(inkJSON, characterPortrait, nametag);
        }
    }

    public void updateDialogueFields(TextAsset dialogue, Sprite character, string names)
    {
        inkJSON = dialogue;
        characterPortrait = character;
        nametag = names;
    }
}
