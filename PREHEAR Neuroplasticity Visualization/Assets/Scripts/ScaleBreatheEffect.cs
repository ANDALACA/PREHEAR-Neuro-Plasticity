using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBreatheEffect : MonoBehaviour
{

    public Vector3 initialScale;
    public Vector3 finalScale;
    private float TimeScale = 0.5f;
    private float ScalingFactor = 1.7f;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        finalScale = new Vector3(initialScale.x + ScalingFactor,
                                 initialScale.y + ScalingFactor,
                                 initialScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            StartCoroutine("ScaleEffect");
        }
    }

    IEnumerator ScaleEffect()
    {
        float progress = 0;

        while (progress <= 1)
        {
            transform.localScale = Vector3.Lerp(initialScale, finalScale, progress);
            progress += Time.deltaTime * TimeScale;
            yield return null;
        }
        transform.localScale = finalScale;
    }
}
