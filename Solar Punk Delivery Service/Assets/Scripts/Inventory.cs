using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

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

    private Potion[] potions;
    [SerializeField]
    private GameObject[] potionGOs;

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

        potions = new Potion[potionGOs.Length];
        for (int i = 0; i < potionGOs.Length; i++)
        {
            potionGOs[i].SetActive(false);
        }
    }

    // Note, this is bad coding practice.
    // There is probably a better way than lising out if statements for numbers,
    // but this is easy and fast for prototyping
    public void ObtainIngredient(Ingredient ingredient)
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

    public bool TryBrewPotion(Potion potion)
    {
        if (CheckIfIngredientsAvailable(potion) == false)
        {
            return false;
        }

        for (int i = 0; i < potion.neededIngredients.Length; i++)
        {
            UseIngredient(potion.neededIngredients[i].id);
        }

        potions[potion.id] = potion;
        potionGOs[potion.id].SetActive(true);
        return true;
    }

    public bool TryGivePotion(Potion potion)
    {
        // TODO
        return false;
    }

    private bool CheckIfIngredientsAvailable(Potion potion)
    {
        for (int i = 0; i < potion.neededIngredients.Length; i++)
        {
            Ingredient ingredient = potion.neededIngredients[i];
            if (ingredient.id == 1 && ingredient1 == null)
            {
                return false;
            }
            if (ingredient.id == 2 && ingredient2 == null)
            {
                return false;
            }
            if (ingredient.id == 3 && ingredient3 == null)
            {
                return false;
            }
            if (ingredient.id == 4 && ingredient4 == null)
            {
                return false;
            }
        }

        return true;
    }

    private void UseIngredient(int ingredientID)
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

    private void UsePotion(int potionID)
    {
        potions[potionID] = null;
        potionGOs[potionID].SetActive(false);
    }
}
