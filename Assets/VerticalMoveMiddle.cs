using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VerticalMoveMiddle : MonoBehaviour
{
    public float verticalSpeed = 5f;
    private int deadZone = 45;

    private void Update()
    {
        MoveLinesUp();
    }

    private void MoveLinesUp()
    {

        Vector3 moveAmount = Vector3.up * verticalSpeed * Time.deltaTime;

        transform.Translate(moveAmount);// move the box collider
        if (transform.position.y > deadZone) Destroy(gameObject); // destroy when out of bounds
    }
}
