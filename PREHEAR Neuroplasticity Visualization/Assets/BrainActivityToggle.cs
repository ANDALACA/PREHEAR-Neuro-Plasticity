using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

public class BrainActivityToggle : MonoBehaviour
{
    public void ToggleBrainActivity(VisualEffect vfxObject)
    {
        if (GetComponent<Toggle>().isOn)
            vfxObject.GetComponent<VisualEffect>().Play();
        else vfxObject.GetComponent<VisualEffect>().Stop();
    }
}
