using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

public class BrainActivityCheeseHighlight : MonoBehaviour
{
    public VisualEffect vfxObject;
    public Text text;
    public GameObject info;

    public void HighlightBrainCheeseActivity()
    {
        vfxObject.GetComponent<VisualEffect>().Play();
        text.text = "Lugtesans";
        info.SetActive(true);
    }

    public void UnhighlightBrainCheeseActivity()
    {
        vfxObject.GetComponent<VisualEffect>().Stop();
        text.text = " ";
        info.SetActive(false);
    }
}
