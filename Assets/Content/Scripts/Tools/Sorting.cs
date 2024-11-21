using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorting : MonoBehaviour
{
    private DragUI drag;
    private Canvas canv;
    [SerializeField] private int LowerSortingIndex = 1;
    [SerializeField] private int UpperSortingIndex = 2;

    private void Awake()
    {
        drag = GetComponent<DragUI>();
        canv = GetComponent<Canvas>();
    }

    public void Start()
    {
        drag.OnStartDrag += SetSorting;
    }

    public void LowerSorting()
    {
        canv.sortingOrder = LowerSortingIndex;
    }

    void SetSorting()
    {
        Sorting[] sorts = FindObjectsOfType<Sorting>(true);
        for (int i = 0; i < sorts.Length; i++)
        {
            sorts[i].LowerSorting();
        }
        canv.sortingOrder = UpperSortingIndex;
    }
}
