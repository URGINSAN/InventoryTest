using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class ItemSorting : DragUI
{
    private Vector2 originalPosition;
    private RectTransform rectTransform;
    private Canvas canv;
    private GraphicRaycaster raycaster;
    private ItemCell itemCell;
    private CanvasGroup canvasGroup;
    private int upperSortOrder = 3;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        itemCell = GetComponent<ItemCell>();
        rectTransform = GetComponent<RectTransform>();
    }

    public override void BeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        GameController.instance.SetCurrentDraggedItem(itemCell);
    }

    public override void EndDrag(PointerEventData eventData)
    {
        Destroy(raycaster);
        Destroy(canv);
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = originalPosition;
    }

    public override void OnPress()
    {
        canv = gameObject.AddComponent<Canvas>();
        canv.overrideSorting = true;
        canv.sortingOrder = upperSortOrder;

        raycaster = gameObject.AddComponent<GraphicRaycaster>();
        canvasGroup.blocksRaycasts = false;
    }
}
