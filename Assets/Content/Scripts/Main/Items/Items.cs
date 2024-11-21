using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class Items : MonoBehaviour
{
    [SerializeField] private string Filename = "InventoryItems.xml";
    private List<Item> ItemsList;
    [Space]
    [SerializeField] private List<Item> PlayerItemsList;
    [SerializeField] private List<Item> DealerItemsList;

    public static Items instance;

    public delegate void LoadDateHandler();
    public event LoadDateHandler OnLoadData;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        GetDataFromXML();
    }

    void GetDataFromXML()
    {
        ItemsList = new List<Item>();
        string filePath = $"{Application.streamingAssetsPath}/{Filename}";

        XDocument xmlDoc = XDocument.Load(filePath);
        XElement root = xmlDoc.Root;

        foreach (XElement itemElement in root.Elements("item"))
        {
            string _name = "";
            int _cost = 0;
            int _soldCost = 0;
            string _spritePath = "";
            string _owner = "";

            Item newItem = new Item();

            XElement nameElement = itemElement.Element("name");
            if (nameElement != null) _name = nameElement.Value;

            XElement costElement = itemElement.Element("cost");
            if (costElement != null) _cost = int.Parse(costElement.Value);

            XElement soldCostElement = itemElement.Element("soldCost");
            if (soldCostElement != null) _soldCost = int.Parse(soldCostElement.Value);

            XElement spriteElement = itemElement.Element("sprite");
            if (spriteElement != null) _spritePath = spriteElement.Value;

            XElement ownerElement = itemElement.Element("owner");
            if (ownerElement != null) _owner = ownerElement.Value;

            newItem.SetItem(_name, _cost, _soldCost, _spritePath, _owner);
            ItemsList.Add(newItem);
        }

        CheckItemsOwner();
        OnLoadData?.Invoke();
    }

    void CheckItemsOwner()
    {
        PlayerItemsList = new List<Item>();
        DealerItemsList = new List<Item>();

        for (int i = 0; i < ItemsList.Count; i++)
        {
            if (ItemsList[i].owner.Equals("player"))
                PlayerItemsList.Add(ItemsList[i]);

            if (ItemsList[i].owner.Equals("dealer"))
                DealerItemsList.Add(ItemsList[i]);
        }
    }

    public List<Item> GetItemsFromTag(string tag)
    {
        List<Item> items = new List<Item>();

        if (tag.Equals("player"))
            items = Items.instance.PlayerItemsList;
        if (tag.Equals("dealer"))
            items = Items.instance.DealerItemsList;

        return items;
    }
}

[System.Serializable]
public struct Item
{
    public string name;
    public int cost;
    public int soldCost;
    public string spritePath;
    public string owner;

    public void SetItem(string _name, int _cost, int _soldCost, string _spritePath, string _owner)
    {
        name = _name;
        cost = _cost;
        soldCost = _soldCost;
        spritePath = _spritePath;
        owner = _owner;
    }
}
