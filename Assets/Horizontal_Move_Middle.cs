using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontal_Move_Middle : MonoBehaviour
{
    private Vector3 touchStartPosition;

    public float horizontalSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float swipeDelta = touch.deltaPosition.x;

                Vector3 moveAmount = Vector3.right * swipeDelta * horizontalSpeed * Time.deltaTime;// Move the object horizontally based on swipeDelta

                transform.Translate(moveAmount);//Move the box collider

            }
        }
    }
}

