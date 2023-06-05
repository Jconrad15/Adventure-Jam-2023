using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton that triggers give potion events to registered functions.
/// </summary>
public class NarrativeEvents : MonoBehaviour
{
    private Action cbOnSleepAfterGivePotion0;
    private Action cbOnSleepAfterGivePotion1;
    private Action cbOnSleepAfterGivePotion2;
    private Action cbOnSleepAfterGivePotion3;
    private Action cbOnSleepAfterGivePotion4;

    public bool[] gavePotion;
    public bool[] triggeredSleepAfterPotion;

    private FadeToBlack fadeToBlack;

    public static NarrativeEvents Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        gavePotion = new bool[5];
        triggeredSleepAfterPotion = new bool[5];
        fadeToBlack = FindAnyObjectByType<FadeToBlack>();
    }

    public void TriggerGivePotion(int potionID)
    {
        gavePotion[potionID] = true;
    }

    public void TriggerSleep()
    {
        // need to check lowest gave potion
        // corresponding with not having slept yet
        fadeToBlack.StartFade();
        for (int i = 0; i < gavePotion.Length; i++)
        {
            //Debug.Log("GavePotion " + i + gavePotion[i]);
            //Debug.Log("triggeredSleepAfterPotion " + i + triggeredSleepAfterPotion[i]);

            if (gavePotion[i] && triggeredSleepAfterPotion[i] == false)
            {
                triggeredSleepAfterPotion[i] = true;
                //Debug.Log("triggeredSleepAfterPotion " + i + triggeredSleepAfterPotion[i]);
                TriggerSleepAfterGivePotion(i);
                return;
            }
        }
    }

    private void TriggerSleepAfterGivePotion(int potionID)
    {
        if (potionID == 0)
        {
            cbOnSleepAfterGivePotion0?.Invoke();
        }
        else if (potionID == 1)
        {
            cbOnSleepAfterGivePotion1?.Invoke();
        }
        else if (potionID == 2)
        {
            cbOnSleepAfterGivePotion2?.Invoke();
        }
        else if (potionID == 3)
        {
            cbOnSleepAfterGivePotion3?.Invoke();
        }
        else if (potionID == 4)
        {
            cbOnSleepAfterGivePotion4?.Invoke();
        }
        else
        {
            Debug.LogError("wrong id");
        }
    }

    public void RegisterOnSleepAfterGivePotion(
        Action callbackfunc, int index)
    {
        if (index == 0)
        {
            RegisterOnSleepAfterGivePotion0(callbackfunc);
        }
        else if (index == 1)
        {
            RegisterOnSleepAfterGivePotion1(callbackfunc);
        }
        else if (index == 2)
        {
            RegisterOnSleepAfterGivePotion2(callbackfunc);
        }
        else if (index == 3)
        {
            RegisterOnSleepAfterGivePotion3(callbackfunc);
        }
        else if (index == 4)
        {
            RegisterOnSleepAfterGivePotion4(callbackfunc);
        }
    }

    public void UnregisterOnSleepAfterGivePotion(Action callbackfunc, int index)
    {
        if (index == 0)
        {
            UnregisterOnSleepAfterGivePotion0(callbackfunc);
        }
        else if (index == 1)
        {
            UnregisterOnSleepAfterGivePotion1(callbackfunc);
        }
        else if (index == 2)
        {
            UnregisterOnSleepAfterGivePotion2(callbackfunc);
        }
        else if (index == 3)
        {
            UnregisterOnSleepAfterGivePotion3(callbackfunc);
        }
        else if (index == 4)
        {
            UnregisterOnSleepAfterGivePotion4(callbackfunc);
        }
    }

    public void RegisterOnAllGivePotion(Action callbackfunc)
    {
        RegisterOnSleepAfterGivePotion0(callbackfunc);
        RegisterOnSleepAfterGivePotion1(callbackfunc);
        RegisterOnSleepAfterGivePotion2(callbackfunc);
        RegisterOnSleepAfterGivePotion3(callbackfunc);
        RegisterOnSleepAfterGivePotion4(callbackfunc);
    }

    private void RegisterOnSleepAfterGivePotion0(Action callbackfunc)
    {
        cbOnSleepAfterGivePotion0 += callbackfunc;
    }

    private void UnregisterOnSleepAfterGivePotion0(Action callbackfunc)
    {
        cbOnSleepAfterGivePotion0 -= callbackfunc;
    }

    private void RegisterOnSleepAfterGivePotion1(Action callbackfunc)
    {
        cbOnSleepAfterGivePotion1 += callbackfunc;
    }

    private void UnregisterOnSleepAfterGivePotion1(Action callbackfunc)
    {
        cbOnSleepAfterGivePotion1 -= callbackfunc;
    }

    private void RegisterOnSleepAfterGivePotion2(Action callbackfunc)
    {
        cbOnSleepAfterGivePotion2 += callbackfunc;
    }

    private void UnregisterOnSleepAfterGivePotion2(Action callbackfunc)
    {
        cbOnSleepAfterGivePotion2 -= callbackfunc;
    }

    private void RegisterOnSleepAfterGivePotion3(Action callbackfunc)
    {
        cbOnSleepAfterGivePotion3 += callbackfunc;
    }

    private void UnregisterOnSleepAfterGivePotion3(Action callbackfunc)
    {
        cbOnSleepAfterGivePotion3 -= callbackfunc;
    }

    private void RegisterOnSleepAfterGivePotion4(Action callbackfunc)
    {
        cbOnSleepAfterGivePotion4 += callbackfunc;
    }

    private void UnregisterOnSleepAfterGivePotion4(Action callbackfunc)
    {
        cbOnSleepAfterGivePotion4 -= callbackfunc;
    }
}
