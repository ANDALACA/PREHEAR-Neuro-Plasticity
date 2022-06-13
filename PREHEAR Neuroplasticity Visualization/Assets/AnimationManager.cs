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
            itemsAnimator.Play("Smell Cheese (Cheese)", -1);
            manAnimator.Play("Smell Cheese (Armature)", -1);
        }

        if (kick)
        {
            itemsAnimator.Play("Kick Ball (Ball)", -1);
            manAnimator.Play("Kick Ball (Armature)", -1);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (smell)
            {
                itemsAnimator.Play("Idle (Items)", -1);
                manAnimator.Play("Idle (Armature)", -1);
            }

            kick = false;
            smell = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (kick)
            {
                itemsAnimator.Play("Idle (Items)", -1);
                manAnimator.Play("Idle (Armature)", -1);
            }

            smell = false;
            kick = true;
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
