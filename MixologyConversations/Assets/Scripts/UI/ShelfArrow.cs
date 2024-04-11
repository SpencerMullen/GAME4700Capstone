using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfArrow : MonoBehaviour
{
    // Enum for left and right
    public enum Direction
    {
        Left,
        Right
    }

    // Direction of the arrow
    public Direction direction;

    // On Click, move the shelf in the direction
    void OnMouseDown()
    {
        // Check if UI is active
        if (UIManager.instance.isUIActive)
        {
            return;
        }
        
        if (direction == Direction.Left)
        {
            ShelfManager.instance.GoLeft();
        }
        else
        {
            ShelfManager.instance.GoRight();
        }
    }
}
