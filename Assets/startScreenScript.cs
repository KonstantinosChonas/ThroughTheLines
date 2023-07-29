using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScreenScript : MonoBehaviour
{
    public bool running = false;
    // Start is called before the first frame update
    void Start()
    {
        if (running==false)
        Time.timeScale = 0f;
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame

}
