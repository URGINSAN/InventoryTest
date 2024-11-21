using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DragUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    private Vector2 offset;
    private RectTransform rectTransform;

    public delegate void StartDragHandler();
    public event StartDragHandler OnStartDrag;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform = GetComponent<RectTransform>();
        OnStartDrag?.Invoke();
        BeginDrag(eventData);
        offset = rectTransform.anchoredPosition - eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = eventData.position + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EndDrag(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnStartDrag?.Invoke();
        OnPress();
    }

    public virtual void BeginDrag(PointerEventData eventData)
    {}

    public virtual void EndDrag(PointerEventData eventData)
    {}

    public virtual void OnPress()
    {}
}