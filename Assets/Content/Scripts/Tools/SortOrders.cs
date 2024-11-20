using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortOrders : MonoBehaviour
{
    public static SortOrders instance;
    [SerializeField] private int LastSortOrder;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public int GetLastSortOrder(bool addOrder)
    {
        int t = LastSortOrder;

        if (addOrder)
            LastSortOrder += 1;

        return t;
    }

    public void AddLastSortOrder()
    {
        LastSortOrder += 1;
    }
}