using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OnClickEvent : MonoBehaviour
{
    [SerializeField] private string eventType;
    [SerializeField] private MixingInventoryManager mixingManager;

    void Start()
    {
        if (mixingManager == null)
        {
            mixingManager = FindObjectOfType<MixingInventoryManager>();
        }
    }

    void OnMouseDown()
    {
        mixingManager.handleMessage(eventType);
    }
}
