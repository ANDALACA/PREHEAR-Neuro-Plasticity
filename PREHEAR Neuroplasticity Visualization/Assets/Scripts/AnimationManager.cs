using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator itemsAnimator;
    public Animator manAnimator;

    private bool smell;
    private bool kick;

    private void Update()
    {
        if (smell)
        {
            itemsAnimator.SetTrigger("smelling trigger");
            manAnimator.SetTrigger("smelling trigger");
            smell = false;
        }

        if (kick)
        {
            itemsAnimator.SetTrigger("kicking trigger");
            manAnimator.SetTrigger("kicking trigger");
            kick = false;
        }
    }

    public void Smell()
    {
        kick = false;
        smell = true;
    }

    public void Kick()
    {
        smell = false;
        kick = true;
    }
}
