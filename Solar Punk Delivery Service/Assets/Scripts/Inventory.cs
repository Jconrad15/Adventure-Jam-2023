using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton for the player's inventory
/// </summary>
public class Inventory : MonoBehaviour
{
    private List<Ingredient> ingredients;
    private List<Potion> potions;

    public static Inventory Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        ingredients = new List<Ingredient>();
        potions = new List<Potion>();
    }




}
