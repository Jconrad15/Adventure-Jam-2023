using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private Ingredient ingredient;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = ingredient.image;
    }

}
