using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAfterSomeTime : MonoBehaviour
{

    public GameObject goToActivate;

    public int secBeforeActive;
    public int secBeforeInactiveAgain;
    public bool deactivateAgain;
    public bool repeat;


    void Start()
    {
        if(repeat)
        {
            if(deactivateAgain)
            {
                InvokeRepeating("caller", 0, secBeforeActive + secBeforeInactiveAgain);
            }
            else
            {
                InvokeRepeating("caller", 0, secBeforeActive);
            }
        }
        goToActivate.gameObject.SetActive(false);
    }

    void caller()
    {
        if (deactivateAgain)
        {
            StartCoroutine(SetObjActive(secBeforeActive, secBeforeInactiveAgain));
        }
        else
        {
            StartCoroutine(SetObjActive(secBeforeActive));
        }
    }

    IEnumerator SetObjActive(int _secBeforeActive)
    {
        yield return new WaitForSeconds(_secBeforeActive);
        goToActivate.gameObject.SetActive(true);
    }
    
    IEnumerator SetObjActive(int _secBeforeActive, int _secBeforeDeactiveAgain)
    {
        yield return new WaitForSeconds(_secBeforeActive);
        goToActivate.gameObject.SetActive(true);
        yield return new WaitForSeconds(_secBeforeDeactiveAgain);
        goToActivate.gameObject.SetActive(false);
    }
}
