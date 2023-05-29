using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton for the player's inventory
/// </summary>
public class Inventory : MonoBehaviour
{
    private Ingredient ingredient1;
    private Ingredient ingredient2;
    private Ingredient ingredient3;
    private Ingredient ingredient4;

    [SerializeField]
    private GameObject ingredient1GO;
    [SerializeField]
    private GameObject ingredient2GO;
    [SerializeField]
    private GameObject ingredient3GO;
    [SerializeField]
    private GameObject ingredient4GO;

    private Potion potion1;
    private Potion potion2;

    [SerializeField]
    private GameObject potion1GO;
    [SerializeField]
    private GameObject potion2GO;

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
        ingredient1GO.SetActive(false);
        ingredient2GO.SetActive(false);
        ingredient3GO.SetActive(false);
        ingredient4GO.SetActive(false);

        potion1GO.SetActive(false);
        potion2GO.SetActive(false);
    }

    // Note, this is bad coding practice.
    // There is probably a better way than lising out if statements for numbers,
    // but this is easy and fast for prototyping
    public void GetIngredient(Ingredient ingredient)
    {
        if (ingredient.id == 1)
        {
            ingredient1 = ingredient;
            ingredient1GO.SetActive(true);
        }
        else if (ingredient.id == 2)
        {
            ingredient2 = ingredient;
            ingredient2GO.SetActive(true);
        }
        else if (ingredient.id == 3)
        {
            ingredient3 = ingredient;
            ingredient3GO.SetActive(true);
        }
        else if (ingredient.id == 4)
        {
            ingredient4 = ingredient;
            ingredient4GO.SetActive(true);
        }
    }

    public void GetPotion(Potion potion)
    {
        if (potion.id == 1)
        {
            potion1 = potion;
            potion1GO.SetActive(true);
        }
        else if (potion.id == 2)
        {
            potion2 = potion;
            potion2GO.SetActive(true);
        }

    }

    public void UseIngredient(int ingredientID)
    {
        if (ingredientID == 1)
        {
            ingredient1 = null;
            ingredient1GO.SetActive(false);
        }
        else if (ingredientID == 2)
        {
            ingredient2 = null;
            ingredient2GO.SetActive(false);
        }
        else if (ingredientID == 3)
        {
            ingredient3 = null;
            ingredient3GO.SetActive(false);
        }
        else if (ingredientID == 4)
        {
            ingredient4 = null;
            ingredient4GO.SetActive(false);
        }
    }

    public void UsePotion(int potionID)
    {
        if (potionID == 1)
        {
            potion1 = null;
            potion1GO.SetActive(false);
        }
        else if (potionID == 2)
        {
            potion2 = null;
            potion2GO.SetActive(false);
        }

    }
}
