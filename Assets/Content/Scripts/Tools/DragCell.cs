using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragCell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 originalPosition;
    private Vector2 offset;
    private RectTransform rectTransform;
    private Canvas canv;
    private GraphicRaycaster raycaster;
    private ItemCell itemCell;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        itemCell = GetComponent<ItemCell>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        offset = rectTransform.anchoredPosition - eventData.position;

        canv = gameObject.AddComponent<Canvas>();
        canv.overrideSorting = true;
        canv.sortingOrder = SortOrders.instance.GetLastSortOrder(false) + 1;

        raycaster = gameObject.AddComponent<GraphicRaycaster>();

        canvasGroup.blocksRaycasts = false;
        GameController.instance.SetCurrentDraggedItem(itemCell);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = eventData.position + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(raycaster);
        Destroy(canv);
        canvasGroup.blocksRaycasts = true;

        rectTransform.anchoredPosition = originalPosition;
    }
}
