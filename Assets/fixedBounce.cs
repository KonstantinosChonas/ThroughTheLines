using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixedBounce : MonoBehaviour
{
    public float bounceForce = 10f; // The force applied to the ball when it bounces

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, 0); // Reset y velocity of ball
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse); // Apply bounce force
        }
    }
}