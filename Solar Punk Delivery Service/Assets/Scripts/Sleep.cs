using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{

    public void StartSleep()
    {
        NarrativeEvents.Instance.TriggerSleep();
    }


}
