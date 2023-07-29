using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    private int score=0;
    public Text scoreText;
    [ContextMenu("Increase score")]
    public void addScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    
}
