using UnityEngine;
using UnityEngine.EventSystems;

public class DropCell : MonoBehaviour, IDropHandler
{
    private ItemsPanel panel;

    void Awake()
    {
        panel = GetComponentInParent<ItemsPanel>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.transform.tag.Equals("Cell"))
        {
            DragCell drag = eventData.pointerDrag.GetComponent<DragCell>();

            if (drag != null)
            {
                GameController.instance.MakeDeal(panel.GetOwner());
            }
        }
    }
}
