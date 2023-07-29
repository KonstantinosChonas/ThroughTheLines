using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class LineSpawnScript : MonoBehaviour
{
    public GameObject Line;
    public float spawnRate = 2;
    private float timer = 0;
    public float widthOffset = 3;
    // Start is called before the first frame update
    void Start()
    {
        spawnLine();
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnLine();
            timer = 0; //Reset the timer
        }

    }
    void spawnLine()
    {
        float rightestPoint = transform.position.x - widthOffset;
        float leftestPoint = transform.position.x + widthOffset;

        Vector3 position = new Vector3(0, -35, 0);
        

        float gap = Random.Range(-14, 14); //where the gap of our lines will be

        Vector3 BoxColliderOffset = new Vector3(gap, 0, 0);

        GameObject parent = Instantiate(Line, position, transform.rotation);// spawn the parent

        LineRenderer child1 = parent.transform.GetChild(0).GetComponent<LineRenderer>();// Get the childrent of the parent Game object
        LineRenderer child2 = parent.transform.GetChild(1).GetComponent<LineRenderer>();
        BoxCollider2D boxCollider1 = parent.transform.GetChild(0).GetComponent<BoxCollider2D>();//right line box collider
        BoxCollider2D boxCollider2 = parent.transform.GetChild(1).GetComponent<BoxCollider2D>();//left line box collider
        //BoxCollider2D boxCollider3 = parent.transform.GetChild(2).GetComponent<BoxCollider2D>();//middle box collider

        //we need to fix the position of the children
        Vector3 start1 = new Vector3(200, -35, 1), end1 = new Vector3(gap + widthOffset, -35, 1);
        child1.SetPosition(0, start1); // Set the start position for Line Renderer 1 (from the parent position).
        child1.SetPosition(1, end1); // Set the end position for Line Renderer 1.
        boxCollider1.transform.Translate(BoxColliderOffset);// Move the line's box collider

        Vector3 start2 = new Vector3(-200, -35, 1), end2 = new Vector3(gap - widthOffset, -35, 1);
        child2.SetPosition(0, start2); // Set the start position for Line Renderer 2 (from the parent position).
        child2.SetPosition(1, end2); // Set the end position for Line Renderer 2.
        boxCollider2.transform.Translate(BoxColliderOffset);// Move the line's box collider


        //boxCollider3.size = new Vector2(2 * widthOffset, 0.2f); //set the size of the middle

        //boxCollider3.transform.Translate(BoxColliderOffset);// Move the middle box collider

    }
}
