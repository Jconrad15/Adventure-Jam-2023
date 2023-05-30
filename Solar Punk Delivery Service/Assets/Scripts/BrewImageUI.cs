using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrewImageUI : MonoBehaviour
{
    [SerializeField]
    private Sprite[] brewImages;
    [SerializeField]
    private Image image;

    public void SetBrewImage(int id)
    {
        image.sprite = brewImages[id];
    }


}
