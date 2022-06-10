using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleChangeCol : MonoBehaviour
{
    public Color onColor;
    public Color offColor;

    public void ChangeBackground()
    {
        if (GetComponent<Toggle>().isOn)
            GetComponent<Image>().color = onColor;
        else
            GetComponent<Image>().color = offColor;
    }
}

