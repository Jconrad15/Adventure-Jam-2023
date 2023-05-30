using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brewing : MonoBehaviour
{
    private CookingTabs tabs;

    [SerializeField]
    private Potion[] potions;

    private void Start()
    {
        tabs = GetComponent<CookingTabs>();
    }

    public void BrewButton()
    {
        int potionID = tabs.ShownPotionID;

        if (Inventory.Instance.TryBrewPotion(potions[potionID]))
        {
            Debug.Log("Brewed");
        }
        else
        {
            Debug.Log("NotBrewed");
        }

    }



}
