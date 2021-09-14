using System;
using System.Collections;
using System.Collections.Generic;
using _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData;
using _Code.AssignmentRelated.StatSystem;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private static Tooltip instance;
    [SerializeField] private RectTransform _tooltipBackground;
    [SerializeField] private Text _tooltipText;
    [SerializeField] private float textPaddingSize = 4.0f;
    private bool _isOpen = false;

    private void Awake()
    {
        instance = this;
        // Code monkey is being dumb :)
        ShowTooltip("hello");
    }

    private void ShowTooltip(string tooltipString)
    {
        if(_isOpen == true)
            return;
        
        _isOpen = true;
        SetTooltipActive(true);
        _tooltipText.text = tooltipString;

        Vector2 backgroundSize = new Vector2(
            _tooltipText.preferredWidth + textPaddingSize*2,
            _tooltipText.preferredHeight + textPaddingSize*2);
        
        _tooltipBackground.sizeDelta = backgroundSize;
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.x = (mousePos.x - Screen.width/2.0f)*1080/Screen.height;
        mousePos.y = (mousePos.y - Screen.height/2.0f) *1080/Screen.height;
        mousePos.z = 0;
        transform.localPosition = mousePos;
    }

    private void HideTooltip()
    {
        SetTooltipActive(false);
    }

    private void SetTooltipActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public static void RequestTooltip(string tooltipMessage)
    {
        instance.ShowTooltip(tooltipMessage);
    }

    public static void RequesetHideTooltip()
    {
        instance.HideTooltip();
    }
}
