using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class middlePass : MonoBehaviour
{
    private Scorer scorer;
    // Start is called before the first frame update
    void Start()
    {
        scorer = GameObject.FindGameObjectWithTag("Scorer").GetComponent<Scorer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scorer.addScore();
    }
}
