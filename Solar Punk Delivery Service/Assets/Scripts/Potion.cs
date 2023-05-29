using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Potion : ScriptableObject
{
    public int id;
    public string potionName;
    public string description;
    public Ingredient[] neededIngredients;
    public Sprite image;
}
