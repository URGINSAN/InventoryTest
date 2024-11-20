using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCell : MonoBehaviour
{
    public Item item;
    [SerializeField] private Image img;
    [SerializeField] private Text nameText;
    [SerializeField] private Text costText;

    public void SetItem(Item _item)
    {
        item = _item;

        img.sprite = SpriteLoader.LoadSprite(item.spritePath);
        nameText.text = item.name;
        costText.text = $"{item.cost}<size=24>₽</size>";
    }
}
