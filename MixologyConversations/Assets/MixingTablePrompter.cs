using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixingTablePrompter : MonoBehaviour
{
/*    void OnEnable()
    {
        //Register Button Events
        promptButton.onClick.AddListener(() => );
    }

    void OnDisable()
    {
        //Un-Register Button Events
        promptButton.onClick.RemoveAllListeners();
    }*/

    public void goToMixingTable()
    {
        Debug.Log("BUTTON IS CLICKING");
        LevelManager.Instance.GameStateChange(GameState.IN_MIXING_TABLE);
    }

    void OnMouseOver()
    {
        Debug.Log("BUTTON IS UNDER MOUSE");
    }
}
