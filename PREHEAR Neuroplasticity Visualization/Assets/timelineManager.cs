using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class timelineManager : MonoBehaviour
{
    public PlayableDirector[] directors;
    public int i;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(directors[i]!=null)
                directors[i].Play();
            i++;
        }
    }
}
