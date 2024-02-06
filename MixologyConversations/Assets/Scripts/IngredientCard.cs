using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IngredientCard : MonoBehaviour
{
    [Header("Text fields")]
    public TextMeshPro titleText;
    public TextMeshPro descriptionText;
    public TextMeshPro costText;

    [Header("Image(s)")]
    public Sprite icon;
    public GameObject iconObject;
}
