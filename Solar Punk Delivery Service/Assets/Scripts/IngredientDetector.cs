using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDetector : MonoBehaviour
{
    private Action cbOnIngredientDetected;

    public void IngredientInRange()
    {
        cbOnIngredientDetected?.Invoke();
    }

    public void RegisterOnIngredientDetected(Action callbackfunc)
    {
        cbOnIngredientDetected += callbackfunc;
    }

    public void UnregisterOnIngredientDetected(Action callbackfunc)
    {
        cbOnIngredientDetected -= callbackfunc;
    }

}
