using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewingUIController : MonoBehaviour
{
    private bool isOpen;
    [SerializeField]
    private GameObject brewingUI;

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        HideBrewingUI();
    }

    private void Update()
    {
        if (isOpen == false) { return; }

        if (Input.GetKeyDown(KeyCode.Escape) ||
            Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D))
        {
            HideBrewingUI();
        }
    }

    public void ShowBrewingUI()
    {
        playerController.DisableMovement();
        brewingUI.SetActive(true);
        isOpen = true;
    }

    public void HideBrewingUI()
    {
        playerController.EnableMovement();
        brewingUI.SetActive(false);
        isOpen = false;
    }
}
