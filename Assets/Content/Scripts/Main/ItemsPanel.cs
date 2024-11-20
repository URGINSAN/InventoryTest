using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsPanel : MonoBehaviour
{
    [SerializeField] private string owner;
    [SerializeField] private string ownerName;
    [SerializeField] private Text ownerText;
    [SerializeField] private GameObject ItemGO;
    [SerializeField] private Transform Grid;

    private void Awake()
    {
        SetPanel();
        
        Items.instance.OnLoadData += LoadItemsToPanel;
    }

    void Start()
    {
        GameController.instance.AddPanel(owner, this);
    }

    void SetPanel()
    {
        ownerText.text = ownerName;
    }

    void LoadItemsToPanel()
    {
        List<Item> items = Items.instance.GetItemsFromTag(owner);

        for (int i = 0; i < items.Count; i++)
        {
            ItemCell itemCell = Instantiate(ItemGO, Grid).GetComponent<ItemCell>();
            itemCell.SetItem(items[i]);
            itemCell.gameObject.name = itemCell.item.name;
        }
    }

    public void AddItem(ItemCell itemCell)
    {
        itemCell.item.owner = owner;
        itemCell.transform.SetParent(Grid);
    }

    public string GetOwner()
    {
        return owner;
    }
}
