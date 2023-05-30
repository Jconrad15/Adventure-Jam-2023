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

    public void Collect()
    {
        Inventory.Instance.ObtainIngredient(ingredient);
        StartCoroutine(DelayedDestroy());
    }

    private IEnumerator DelayedDestroy()
    {
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }

}
