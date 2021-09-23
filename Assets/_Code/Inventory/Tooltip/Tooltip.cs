using System;
using _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    private static Tooltip instance;
    [SerializeField] private RectTransform _tooltipBackground;
    [SerializeField] private RectTransform _canvas;
    [SerializeField] private Text _tooltipText;
    [SerializeField] private float textPaddingSize = 4.0f;
    [SerializeField] private float screenPadding = 40.0f;
    private Func<string> getTooltipStringFunc = () => "";

    private void Awake()
    {
        instance = this;
        HideTooltip();
    }

    private void ShowTooltip(string tooltipString)
    {
        ShowTooltip(() => tooltipString);
    }

    private void ShowTooltip(Func<string> getTooltipStringFunc)
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
        this.getTooltipStringFunc = getTooltipStringFunc;
        SetTooltipText(this.getTooltipStringFunc());
    }

    private void SetTooltipText(string tooltipText)
    {
        _tooltipText.text = tooltipText;
        Vector2 backgroundSize = new Vector2(
            _tooltipText.preferredWidth + textPaddingSize * 2,
            _tooltipText.preferredHeight + textPaddingSize * 2);

        _tooltipBackground.sizeDelta = backgroundSize;
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(),
            Input.mousePosition, null, out localPoint);
        transform.localPosition = localPoint;

        SetTooltipText(getTooltipStringFunc());
        
        Vector2 anchoredPosition = transform.GetComponent<RectTransform>().anchoredPosition;
        if (anchoredPosition.x + _tooltipBackground.rect.width/2 > _canvas.rect.width - screenPadding || anchoredPosition.x < 0)
        {
            anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, 0, _canvas.rect.width - (screenPadding + _tooltipBackground.rect.width/2));
        }

        if (anchoredPosition.y + _tooltipBackground.rect.height + screenPadding > _canvas.rect.height || anchoredPosition.y < 0)
        {
            anchoredPosition.y =
                Mathf.Clamp(anchoredPosition.y, 0, _canvas.rect.height - (screenPadding + _tooltipBackground.rect.height));
        }

        transform.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
    }
    
    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public static void AddTooltip(Transform transform, string tooltipText)
    {
        AddTooltip(transform, () => tooltipText);
    }

    public static void AddTooltip(Transform transform, Func<string> getTooltipStringFunc)
    {
        Button_UI targetButton = transform.GetComponent<Button_UI>();
        if (targetButton != null)
        {
            targetButton.MouseOverOnceTooltipFunc = () => Tooltip.RequestTooltip( getTooltipStringFunc);
            targetButton.MouseOutOnceTooltipFunc = () => Tooltip.RequestHideTooltip();
        }
    }

    public static void RequestTooltip(Func<string> tooltipFunc)
    {
        instance.ShowTooltip(tooltipFunc);
    }

    public static void RequestHideTooltip()
    {
        instance.HideTooltip();
    }

    public static void RequestItemTooltip(InventoryItemBase item)
    {
        // item
    }
}