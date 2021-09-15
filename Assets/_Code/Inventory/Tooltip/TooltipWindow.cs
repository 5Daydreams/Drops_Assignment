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
    [SerializeField] private InventorySlot _slotInfo;

    private void Awake()
    {
        _button = GetComponent<Button_UI>();

        Tooltip.AddTooltip(this.transform, () => "Hello");
    }
}
