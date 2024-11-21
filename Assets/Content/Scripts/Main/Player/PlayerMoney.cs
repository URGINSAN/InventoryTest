using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney instance;
    [SerializeField] private int money;

    public delegate void MoneyChangeHandler(int _money);
    public event MoneyChangeHandler OnMoneyChange;
    private Player player;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        player = Player.instance;
        player.OnLoadData += GetStartMoney;
    }

    void GetStartMoney()
    {
        money = player.GetPlayerMoney();
        OnMoneyChange?.Invoke(money);
    }

    public bool CanBuy(int cost)
    {
        bool can = false;

        if (money >= cost)
        {
            can = true;
        }
        else
        {
            OnNoMoney();
        }

        return can;
    }

    public void ChangeMoney(int count)
    {
        money += count;
        OnMoneyChange?.Invoke(money);
    }

    void OnNoMoney()
    {

    }
}
