using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionTable : MonoBehaviour
{
    BrewingUIController brewingUIController;

    private void Start()
    {
        brewingUIController = FindAnyObjectByType<BrewingUIController>();
    }

    public void OpenBrewingUI()
    {
        brewingUIController.ShowBrewingUI();
    }

}
