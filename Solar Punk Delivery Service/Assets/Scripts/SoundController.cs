using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip cannotMoveNoise;

    [SerializeField]
    private AudioClip successSound;

    [SerializeField]
    private Brewing brewing;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        FindAnyObjectByType<PlayerController>()
            .RegisterOnPlayerCannotMove(OnPlayerCannotMove);

        brewing.RegisterOnBrewPotion(OnBrewPotion);
    }

    private void OnPlayerCannotMove()
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.clip = cannotMoveNoise;
            audioSource.Play();
        }
    }

    private void OnBrewPotion()
    {
        audioSource.PlayOneShot(successSound);
    }

}
