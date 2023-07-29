using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBorder : MonoBehaviour
{
    private string targetTag = "Ball";

    private GameLogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogicScript>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered with collider tag: " + collision.tag);

        if (collision.CompareTag(targetTag) == true)
        {
            logic.gameOver();
        }
    }
}
