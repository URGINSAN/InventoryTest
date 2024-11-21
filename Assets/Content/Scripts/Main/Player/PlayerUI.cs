using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : DragUI
{
    [SerializeField] private Text playerMoneyText;

    private void Start()
    {
        PlayerMoney.instance.OnMoneyChange += UpdateUI;
    }

    void UpdateUI(int money)
    {
        playerMoneyText.text = money.ToString();
    }
}
