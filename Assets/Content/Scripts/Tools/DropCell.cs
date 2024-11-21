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
            ItemCell item = eventData.pointerDrag.GetComponent<ItemCell>();

            if (item != null)
            {
                GameController.instance.MakeDeal(panel.GetOwner());
            }
        }
    }
}
