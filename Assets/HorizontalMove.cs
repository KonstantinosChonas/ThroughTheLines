using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HorizontalMove : MonoBehaviour
{
    private Vector3 touchStartPosition;

    //private bool isMoving = false; 


    public float horizontalSpeed = 1.5f;

    // Update is called once per frame
    void Update()
    {

        LineRenderer LrRight = transform.GetChild(0).GetComponent<LineRenderer>();// Get the childrent of the parent Game object
        LineRenderer LrLeft= transform.GetChild(1).GetComponent<LineRenderer>();
        BoxCollider2D boxColliderLeft = transform.GetChild(0).GetComponent<BoxCollider2D>();//right line box collider
        BoxCollider2D boxColliderRight = transform.GetChild(1).GetComponent<BoxCollider2D>();//left line box collider
        BoxCollider2D boxColliderMiddle = transform.GetChild(2).GetComponent<BoxCollider2D>();//middle box collider

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float swipeDelta = touch.deltaPosition.x;

                Vector3 moveAmount = Vector3.right * swipeDelta * horizontalSpeed * Time.deltaTime;// Move the object horizontally based on swipeDelta




                Vector3[] linePositionsRight = new Vector3[LrRight.positionCount];  //
                                                                                    //
                for (int i = 0; i < linePositionsRight.Length; i++)
                {                                                                           //
                    linePositionsRight[i] = LrRight.GetPosition(i) + moveAmount;                //Move line renderer 
                }                                                                           //
                                                                                            //
                LrRight.SetPositions(linePositionsRight);                           //



                Vector3[] linePositionsLeft = new Vector3[LrLeft.positionCount];  //
                                                                               //
                for (int i = 0; i < linePositionsLeft.Length; i++)
                {                                                                           //
                    linePositionsLeft[i] = LrLeft.GetPosition(i) + moveAmount;                //Move line renderer 
                }                                                                           //
                                                                                            //
                LrLeft.SetPositions(linePositionsLeft);                           //

                transform.Translate(moveAmount);//Move the box colliders


            }
        }
    }
}

