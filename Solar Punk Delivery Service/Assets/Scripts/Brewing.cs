using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brewing : MonoBehaviour
{
    private CookingTabs tabs;

    [SerializeField]
    private Potion[] potions;

    [SerializeField]
    private Animator animator;

    private Action cbOnBrewPotion;

    private void Start()
    {
        tabs = GetComponent<CookingTabs>();
    }

    public void BrewButton()
    {
        int potionID = tabs.ShownPotionID;

        if (Inventory.Instance.TryBrewPotion(potions[potionID]))
        {
            Debug.Log("Brewed id " + potionID);
            animator.SetTrigger("StartBrew");
            cbOnBrewPotion?.Invoke();
        }
        else
        {
            Debug.Log("NotBrewed");
        }

    }

    public Potion[] GetPotions()
    {
        return potions;
    }

    public void RegisterOnBrewPotion(Action callbackfunc)
    {
        cbOnBrewPotion += callbackfunc;
    }

    public void UnregisterOnBrewPotion(Action callbackfunc)
    {
        cbOnBrewPotion -= callbackfunc;
    }

}
