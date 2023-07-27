using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Horizontal_move : MonoBehaviour
{
    private Vector3 touchStartPosition;

    //private bool isMoving = false; 

    private LineRenderer lineRenderer;

    public float horizontalSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        lineRenderer = GetComponent<LineRenderer>();


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float swipeDelta = touch.deltaPosition.x;

                Vector3 moveAmount = Vector3.right * swipeDelta * horizontalSpeed * Time.deltaTime;// Move the object horizontally based on swipeDelta


                

                Vector3[] linePositions = new Vector3[lineRenderer.positionCount];  //
                                                                                    //
                for (int i = 0; i < linePositions.Length; i++)
                {                                                                           //
                    linePositions[i] = lineRenderer.GetPosition(i) + moveAmount;                //Move line renderer 
                }                                                                           //
                                                                                            //
                lineRenderer.SetPositions(linePositions);                           //

                transform.Translate(moveAmount);//Move the box collider


            }
        }
    }
 }

