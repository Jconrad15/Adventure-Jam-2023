using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

/// <summary>
/// Singleton for the player's inventory
/// </summary>
public class Inventory : MonoBehaviour
{
    private Ingredient[] ingredients;

    [SerializeField]
    private GameObject[] ingredientGOs;

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
        potions = new Potion[potionGOs.Length];
        for (int i = 0; i < potionGOs.Length; i++)
        {
            potionGOs[i].SetActive(false);
        }

        ingredients = new Ingredient[ingredientGOs.Length];
        for (int i = 0; i < ingredientGOs.Length; i++)
        {
            ingredientGOs[i].SetActive(false);
        }
    }

    public void ObtainIngredient(Ingredient ingredient)
    {
        ingredients[ingredient.id] = ingredient;
        ingredientGOs[ingredient.id].SetActive(true);
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

    private bool CheckIfIngredientsAvailable(Potion potion)
    {
        for (int i = 0; i < potion.neededIngredients.Length; i++)
        {
            Ingredient ingredient = potion.neededIngredients[i];
            if (ingredient.id == 0 && ingredients[ingredient.id] == null)
            {
                return false;
            }
            if (ingredient.id == 1 && ingredients[ingredient.id] == null)
            {
                return false;
            }
            if (ingredient.id == 2 && ingredients[ingredient.id] == null)
            {
                return false;
            }
            if (ingredient.id == 3 && ingredients[ingredient.id] == null)
            {
                return false;
            }
        }

        return true;
    }

    private void UseIngredient(int ingredientID)
    {
        ingredients[ingredientID] = null;
        ingredientGOs[ingredientID].SetActive(false);
    }

    private void UsePotion(int potionID)
    {
        potions[potionID] = null;
        potionGOs[potionID].SetActive(false);
    }

    public bool TryGivePotion(Potion potionToCheckFor)
    {
        bool hasPotion = potions.Contains(potionToCheckFor);

        if (hasPotion)
        {
            UsePotion(potionToCheckFor.id);
            // trigger event 
            NarrativeEvents.Instance.TriggerGivePotion(potionToCheckFor.id);
        }

        return hasPotion;
    }
}
