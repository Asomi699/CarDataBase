using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ScreenBase : DataBaseElement
{
    public void Show()
    {
        MakeVisibility(true);
    }

    public void Hide()
    {
        MakeVisibility(false);
    }

    private void MakeVisibility(bool visible)
    {
        GetComponent<CanvasGroup>().alpha = Convert.ToInt32(visible);
        GetComponent<CanvasGroup>().interactable = visible;
    }
}
