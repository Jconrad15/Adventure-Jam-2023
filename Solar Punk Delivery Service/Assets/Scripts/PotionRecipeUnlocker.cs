using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionRecipeUnlocker : MonoBehaviour
{
    [SerializeField]
    private GameObject potion2;
    [SerializeField]
    private GameObject potion3;
    [SerializeField]
    private GameObject potion4;

    private void Start()
    {
        potion2.SetActive(false);
        potion3.SetActive(false);
        potion4.SetActive(false);

        NarrativeEvents.Instance.RegisterOnGivePotion(OnGivePotion1, 1);
        NarrativeEvents.Instance.RegisterOnGivePotion(OnGivePotion2, 2);
        NarrativeEvents.Instance.RegisterOnGivePotion(OnGivePotion3, 3);
    }

    private void OnGivePotion1()
    {
        potion2.SetActive(true);
    }

    private void OnGivePotion2()
    {
        potion3.SetActive(true);
    }

    private void OnGivePotion3()
    {
        potion4.SetActive(true);
    }

}
