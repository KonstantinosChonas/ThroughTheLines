using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middlePass : MonoBehaviour
{
    private GameLogicScript scorer;
    // Start is called before the first frame update
    void Start()
    {
        scorer = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform parent = transform.parent;
        BoxCollider2D left=parent.GetChild(0).GetComponent<BoxCollider2D>();
        BoxCollider2D right=parent.GetChild(1).GetComponent<BoxCollider2D>();
        BoxCollider2D middle = parent.GetChild(2).GetComponent<BoxCollider2D>();

        Destroy(left);
        Destroy(right);
        Destroy(middle);
        scorer.addScore();

    }
}
