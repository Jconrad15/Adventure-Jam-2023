using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PotionDetailUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI[] descriptionTexts;
    [SerializeField]
    private TextMeshProUGUI[] nameTexts;

    private void Start()
    {
        DisplayPotionDetials();
    }

    private void DisplayPotionDetials()
    {
        Potion[] potions = FindAnyObjectByType<Brewing>().GetPotions();

        for (int i = 0; i < potions.Length; i++)
        {
            {
                descriptionTexts[i].SetText(potions[i].description);
                nameTexts[i].SetText(potions[i].potionName);
            }
        }
    }
}
