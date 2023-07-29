using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameLogicScript : MonoBehaviour
{
    private int highscore;

    public Text highscoreText;

    private startScreenScript running;
    public GameObject startScreen;
    public GameObject GameOver;
    public GameObject Ball;
    private int score=0;
    public Text scoreText;
    [ContextMenu("Increase score")]

    public void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    public void addScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save(); // Save the data immediately
        }
        highscoreText.text = "Highscore: "+highscore.ToString();
        GameOver.SetActive(true);
        
        Destroy(Ball);
    }
    public void startGame()
    {
        running = GameObject.FindGameObjectWithTag("startScreen").GetComponent<startScreenScript>();
        running.running = true;
        startScreen.SetActive(false);
        Time.timeScale = 1f;

    }

    public void ResetHighscore()
    {
        highscore = 0;
        PlayerPrefs.DeleteKey("Highscore");
        PlayerPrefs.Save();
    }

}
