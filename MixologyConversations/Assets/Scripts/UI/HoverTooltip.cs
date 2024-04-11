using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTooltip : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    public string tooltipText;
    private float delay = 0.5f;

    // public void OnPointerEnter(PointerEventData eventData)
    // Use OnMouseEnter instead of OnPointerEnter
    public void OnMouseEnter()
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    // public void OnPointerExit(PointerEventData eventData)
    // Use OnMouseExit instead of OnPointerExit
    public void OnMouseExit()
    {
        StopAllCoroutines();
        TooltipManager.OnMouseLoseFocus();
    }

    private void ShowMessage()
    {
        TooltipManager.OnMouseHover(tooltipText, Input.mousePosition);
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(delay);
        ShowMessage();
    }

    public void SetTooltip(string text)
    {
        tooltipText = text;
    }
}
