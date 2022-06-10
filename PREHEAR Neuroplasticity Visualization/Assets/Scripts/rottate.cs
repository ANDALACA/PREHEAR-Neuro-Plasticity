using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rottate : MonoBehaviour
{
    public Transform brainObject;
    public Vector3 resetRotVal;
    public Vector3 resetPosVal;
    [Range(.01f, .04f)]
    public float rotationSpeed;
    [Range(.001f, .004f)]
    public float zoomSpeed;

    public Vector2 _startPosition;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            // GET TOUCH 0
            Touch touch0 = Input.GetTouch(0);

            // APPLY ROTATION
            if (touch0.phase == TouchPhase.Moved)
            {
                brainObject.transform.Rotate(touch0.deltaPosition.y * rotationSpeed, -touch0.deltaPosition.x * rotationSpeed, 0f, Space.World);
            }
        }

        //Two finger rotation
        if(Input.touchCount == 2)
        {
            var touchOne = Input.GetTouch(0);
            var touchTwo = Input.GetTouch(1);

            if (touchOne.phase == TouchPhase.Began
                || touchTwo.phase == TouchPhase.Began)
            {
                _startPosition = touchTwo.position - touchOne.position;
            }

            if (touchOne.phase == TouchPhase.Moved
                || touchTwo.phase == TouchPhase.Moved)
            {
                var currVector = touchTwo.position - touchOne.position;
                var angle = Vector2.SignedAngle(_startPosition, currVector);
                brainObject.transform.RotateAround(brainObject.position, new Vector3(0,0,1), angle);
                _startPosition = currVector;
            }
        }

        if (Input.touchCount == 2)
        {

            // get current touch positions
            Touch tZero = Input.GetTouch(0);
            Touch tOne = Input.GetTouch(1);
            // get touch position from the previous frame
            Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
            Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

            float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
            float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

            // get offset value
            float deltaDistance = oldTouchDistance - currentTouchDistance;
            ZoomEffect(deltaDistance, zoomSpeed);
        }
    }

    public void ResetPose()
    {
        brainObject.eulerAngles = resetRotVal;
        brainObject.position = resetPosVal;
    }

    public void ZoomEffect(float dist, float _zoomSpeed)
    {
        if (brainObject.position.z > 10)
        {
            brainObject.position = new Vector3(brainObject.position.x, brainObject.position.y, 10);
        }   else if (brainObject.position.z < -5)
        {
            brainObject.position = new Vector3(brainObject.position.x, brainObject.position.y, -5);
        }
        else
        {
            brainObject.position += new Vector3(0, 0, dist * _zoomSpeed);
        }
    }
}
