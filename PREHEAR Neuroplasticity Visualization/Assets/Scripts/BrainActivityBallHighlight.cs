using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

public class BrainActivityBallHighlight : MonoBehaviour
{
    public VisualEffect vfxObject;
    public Text text;
    public GameObject info;

    public void HighlightBrainBallActivity()
    {
        vfxObject.GetComponent<VisualEffect>().Play();
        text.text = "Motorik";
        info.SetActive(true);
    }

    public void UnhighlightBrainBallActivity()
    {
        vfxObject.GetComponent<VisualEffect>().Stop();
        text.text = " ";
        info.SetActive(false);
    }
}
