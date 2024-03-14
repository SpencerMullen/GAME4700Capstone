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
        if (Input.GetMouseButtonDown(0) && !DialogueManager.Active)
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
}
