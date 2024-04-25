using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatingScreenClose : MonoBehaviour
{

    void OnMouseDown()
    {
        LevelManager.Instance.GameStateChange(GameState.WAIT_FOR_CUSTOMER);
    }
}
