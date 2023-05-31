using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton that triggers give potion events to registered functions.
/// </summary>
public class NarrativeEvents : MonoBehaviour
{
    private Action cbOnGivePotion0;
    private Action cbOnGivePotion1;
    private Action cbOnGivePotion2;
    private Action cbOnGivePotion3;
    private Action cbOnGivePotion4;

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

    public void TriggerGivePotion(int potionID)
    {
        if (potionID == 0)
        {
            cbOnGivePotion0?.Invoke();
        }
        else if (potionID == 1)
        {
            cbOnGivePotion1?.Invoke();
        }
        else if (potionID == 2)
        {
            cbOnGivePotion2?.Invoke();
        }
        else if (potionID == 3)
        {
            cbOnGivePotion3?.Invoke();
        }
        else if (potionID == 4)
        {
            cbOnGivePotion4?.Invoke();
        }
        else
        {
            Debug.LogError("wrong id");
        }
    }

    public void RegisterOnGivePotion(Action callbackfunc, int index)
    {
        if (index == 0)
        {
            RegisterOnGivePotion0(callbackfunc);
        }
        else if (index == 1)
        {
            RegisterOnGivePotion1(callbackfunc);
        }
        else if (index == 2)
        {
            RegisterOnGivePotion2(callbackfunc);
        }
        else if (index == 3)
        {
            RegisterOnGivePotion3(callbackfunc);
        }
        else if (index == 4)
        {
            RegisterOnGivePotion4(callbackfunc);
        }
    }

    public void UnregisterOnGivePotion(Action callbackfunc, int index)
    {
        if (index == 0)
        {
            UnregisterOnGivePotion0(callbackfunc);
        }
        else if (index == 1)
        {
            UnregisterOnGivePotion1(callbackfunc);
        }
        else if (index == 2)
        {
            UnregisterOnGivePotion2(callbackfunc);
        }
        else if (index == 3)
        {
            UnregisterOnGivePotion3(callbackfunc);
        }
        else if (index == 4)
        {
            UnregisterOnGivePotion4(callbackfunc);
        }
    }

    private void RegisterOnGivePotion0(Action callbackfunc)
    {
        cbOnGivePotion0 += callbackfunc;
    }

    private void UnregisterOnGivePotion0(Action callbackfunc)
    {
        cbOnGivePotion0 -= callbackfunc;
    }

    private void RegisterOnGivePotion1(Action callbackfunc)
    {
        cbOnGivePotion1 += callbackfunc;
    }

    private void UnregisterOnGivePotion1(Action callbackfunc)
    {
        cbOnGivePotion1 -= callbackfunc;
    }

    private void RegisterOnGivePotion2(Action callbackfunc)
    {
        cbOnGivePotion2 += callbackfunc;
    }

    private void UnregisterOnGivePotion2(Action callbackfunc)
    {
        cbOnGivePotion2 -= callbackfunc;
    }

    private void RegisterOnGivePotion3(Action callbackfunc)
    {
        cbOnGivePotion3 += callbackfunc;
    }

    private void UnregisterOnGivePotion3(Action callbackfunc)
    {
        cbOnGivePotion3 -= callbackfunc;
    }

    private void RegisterOnGivePotion4(Action callbackfunc)
    {
        cbOnGivePotion4 += callbackfunc;
    }

    private void UnregisterOnGivePotion4(Action callbackfunc)
    {
        cbOnGivePotion4 -= callbackfunc;
    }
}
