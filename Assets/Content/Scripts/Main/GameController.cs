using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [Space]
    private ItemCell CurrentDraggedItem;
    private ItemsPanel PlayerPanel;
    private ItemsPanel DealerPanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        Application.targetFrameRate = -1;
    }

    public void SetCurrentDraggedItem(ItemCell itemCell)
    {
        CurrentDraggedItem = itemCell;
    }

    public void AddPanel(string _owner, ItemsPanel _panel)
    {
        if (_owner.Equals("player"))
            PlayerPanel = _panel;
        if (_owner.Equals("dealer"))
            DealerPanel = _panel;
    }

    public void MakeDeal(string dropOwner)
    {
        if (CurrentDraggedItem != null)
        {
            if (CurrentDraggedItem.item.owner.Equals(dropOwner))
                return;

            if (CurrentDraggedItem.item.owner.Equals("player"))
            {
                AttemptSold();
                return;
            }
            if (CurrentDraggedItem.item.owner.Equals("dealer"))
            {
                AttemptBuy();
                return;
            }
        }
    }

    void AttemptBuy()
    {
        if (PlayerMoney.instance.CanBuy(CurrentDraggedItem.item.cost))
        {
            PlayerMoney.instance.ChangeMoney(-CurrentDraggedItem.item.cost);
            PlayerPanel.AddItem(CurrentDraggedItem);
        }
    }

    void AttemptSold()
    {
        PlayerMoney.instance.ChangeMoney(CurrentDraggedItem.item.soldCost);
        DealerPanel.AddItem(CurrentDraggedItem);
    }
}
