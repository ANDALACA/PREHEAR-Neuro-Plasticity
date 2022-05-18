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

        if(Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            //Find what's left and right


            //Rot 1
            if (touch0.position.x < touch1.position.x)
            {
                //Counter clockwise
                if(touch0.deltaPosition.x > 0 && touch0.deltaPosition.y > 0 && touch1.deltaPosition.x < 0 && touch1.deltaPosition.y < 0)
                {
                    print("counter clockwise");
                    brainObject.transform.Rotate(0f, 0f, rotationSpeed * -5, Space.World);
                }

                //Clockwise
                if (touch0.deltaPosition.x < 0 && touch0.deltaPosition.y < 0 && touch1.deltaPosition.x > 0 && touch1.deltaPosition.y > 0)
                {
                    print("clockwise");
                    brainObject.transform.Rotate(0f, 0f, rotationSpeed * 5, Space.World);
                }
            }
            else //Rot 2
            {
                //Counter clockwise
                if (touch0.deltaPosition.x < 0 && touch0.deltaPosition.y > 0 && touch1.deltaPosition.x > 0 && touch1.deltaPosition.y < 0)
                {
                    print("counter clockwise");
                    brainObject.transform.Rotate(0f, 0f, rotationSpeed * -5, Space.World);
                }

                //Clockwise
                if (touch0.deltaPosition.x > 0 && touch0.deltaPosition.y < 0 && touch1.deltaPosition.x < 0 && touch1.deltaPosition.y > 0)
                {
                    print("clockwise");
                    brainObject.transform.Rotate(0f, 0f, rotationSpeed * 5, Space.World);
                }
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
        brainObject.position += new Vector3(0,0,dist * _zoomSpeed);
    }
}
