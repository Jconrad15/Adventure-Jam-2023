using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingTabs : MonoBehaviour
{
    [SerializeField]
    private Canvas[] tabs;
    [SerializeField]
    private Canvas[] potionDetails;

    private BrewImageUI brewImageUI;

    public int ShownPotionID { get; private set; }

    private void Start()
    {
        brewImageUI = GetComponent<BrewImageUI>();

        ShownPotionID = 0;
        SortUI(ShownPotionID);
    }

    public void ButtonA()
    {
        ShownPotionID = 0;
        SortUI(ShownPotionID);
    }

    public void ButtonB()
    {
        ShownPotionID = 1;
        SortUI(ShownPotionID);
    }

    public void ButtonC()
    {
        ShownPotionID = 2;
        SortUI(ShownPotionID);
    }

    public void ButtonD()
    {
        ShownPotionID = 3;
        SortUI(ShownPotionID);
    }

    public void ButtonE()
    {
        ShownPotionID = 4;
        SortUI(ShownPotionID);
    }

    private void SortUI(int topTabIndex)
    {
        EditSortingOrder(topTabIndex, tabs);
        EditSortingOrder(topTabIndex, potionDetails);

        brewImageUI.SetBrewImage(topTabIndex);
    }

    private void EditSortingOrder(int topTabIndex, Canvas[] canvases)
    {
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].sortingOrder = i;
        }

        canvases[topTabIndex].sortingOrder = canvases.Length + 1;
    }
}
