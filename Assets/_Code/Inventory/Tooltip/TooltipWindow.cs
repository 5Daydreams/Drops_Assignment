using System;
using System.Collections;
using System.Collections.Generic;
using BrackeysImport._Code.Inventory;
using CodeMonkey.Utils;
using UnityEngine;

[RequireComponent(typeof(Button_UI))]
public class TooltipWindow : MonoBehaviour
{
    private Button_UI _button;
    private string tooltipText = "";

    private void Awake()
    {
        _button = GetComponent<Button_UI>();
        
        tooltipText = "";

        Tooltip.AddTooltip(this.transform, () => tooltipText);
    }

    public void AdaptTooltip(string newTooltip)
    {
        tooltipText = newTooltip;
    }
}
