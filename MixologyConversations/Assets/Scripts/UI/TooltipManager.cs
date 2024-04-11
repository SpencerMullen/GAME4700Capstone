using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class TooltipManager : MonoBehaviour
{
    public RectTransform tooltipWindow;
    public TextMeshProUGUI tooltipText;

    public static Action<string, Vector2> OnMouseHover;
    public static Action OnMouseLoseFocus;

    private void OnEnable()
    {
        OnMouseHover += ShowTooltip;
        OnMouseLoseFocus += HideTooltip;
    }

    private void OnDisable()
    {
        OnMouseHover -= ShowTooltip;
        OnMouseLoseFocus -= HideTooltip;
    }

    // Start is called before the first frame update
    void Start()
    {
        HideTooltip();
    }

    private void ShowTooltip(string tooltipString, Vector2 position)
    {
        // Debug.Log("Showing tooltip");
        tooltipText.text = tooltipString;
        
        tooltipWindow.sizeDelta = new Vector2(tooltipText.preferredWidth + 6, tooltipText.preferredHeight + 6);
        // Set the tooltip text size to the preferred size
        tooltipText.rectTransform.sizeDelta = new Vector2(tooltipText.preferredWidth, tooltipText.preferredHeight);

        tooltipWindow.gameObject.SetActive(true);
        tooltipWindow.position = new Vector2(Input.mousePosition.x + tooltipWindow.sizeDelta.x / 2 + 10, Input.mousePosition.y);
    }

    private void HideTooltip()
    {
        // Debug.Log("Hiding tooltip");
        tooltipText.text = "";
        tooltipWindow.gameObject.SetActive(false);
    }
}
