using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMove : MonoBehaviour
{
    public float verticalSpeed = 5f;
    private int deadZone = 45;

    private void Update()
    {

        LineRenderer LrRight = transform.GetChild(0).GetComponent<LineRenderer>();// Get the childrent of the parent Game object
        LineRenderer LrLeft = transform.GetChild(1).GetComponent<LineRenderer>();
        BoxCollider2D boxColliderLeft = transform.GetChild(0).GetComponent<BoxCollider2D>();//right line box collider
        BoxCollider2D boxColliderRight = transform.GetChild(1).GetComponent<BoxCollider2D>();//left line box collider
        BoxCollider2D boxColliderMiddle = transform.GetChild(2).GetComponent<BoxCollider2D>();//middle box collider


        MoveLinesUp(LrRight,LrLeft);
    }

    private void MoveLinesUp(LineRenderer LrRight,LineRenderer LrLeft)
    {

        Vector3 moveAmount = Vector3.up * verticalSpeed * Time.deltaTime;



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




        // Move the entire GameObject containing the Box Colliders 2D
        transform.Translate(moveAmount);
        if (transform.position.y > deadZone) Destroy(gameObject);
    }
}
