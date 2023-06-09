using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkSound : MonoBehaviour
{
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayerController playerController =
            FindAnyObjectByType<PlayerController>();

        playerController.RegisterOnPlayerStartMove(OnStartMove);
        playerController.RegisterOnPlayerFinishMove(OnFinishMove);
    }

    private void OnStartMove(Vector2 position)
    {
        audioSource.Play();
    }

    private void OnFinishMove(Vector2 position)
    {
        audioSource.Pause();
    }

}
