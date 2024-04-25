using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixingTablePrompter : MonoBehaviour
{
    public Button promptButton;

    void OnEnable()
    {
        //Register Button Events
        promptButton.onClick.AddListener(() => LevelManager.Instance.GameStateChange(GameState.IN_MIXING_TABLE));
    }

    void OnDisable()
    {
        //Un-Register Button Events
        promptButton.onClick.RemoveAllListeners();
    }
}
