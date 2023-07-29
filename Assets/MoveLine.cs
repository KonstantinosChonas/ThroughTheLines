using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveLine : MonoBehaviour
{
    public float verticalSpeed = 5f;
    private int deadZone = 45;
    private LineRenderer lineRenderer;

    private void Update()
    {
        lineRenderer = GetComponent<LineRenderer>();
        MoveLinesUp();
    }

    private void MoveLinesUp()
    {

        Vector3 moveAmount = Vector3.up * verticalSpeed * Time.deltaTime;
        Vector2 moveMiddle = Vector2.up * verticalSpeed * Time.deltaTime;


        Vector3[] linePositions = new Vector3[lineRenderer.positionCount];        //
                                                                                    // 
        for (int i = 0; i < linePositions.Length; i++)                                //
        {                                                                               // Move the line renderer
            linePositions[i] = lineRenderer.GetPosition(i) + moveAmount;             //
        }                                                                         //
                                                                               //
        lineRenderer.SetPositions(linePositions);                           //


        

        // Move the entire GameObject containing both the Line Renderer and the Box Collider 2D
        transform.Translate(moveAmount);
        BoxCollider2D middleBoxCollider = transform.GetChild(2).GetComponent<BoxCollider2D>();//middle box collider

        //middleBoxCollider.offset = moveMiddle;
        //middleBoxCollider.transform.Translate(moveAmount);
        middleBoxCollider.transform.position= middleBoxCollider.transform.position + moveAmount;
        if (transform.position.y > deadZone) Destroy(gameObject);
    }
}