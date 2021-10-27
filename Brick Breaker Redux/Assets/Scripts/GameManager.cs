using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;


    //Gameover is start false
    public bool gameOver;
    //Holds the gameover panel
    public GameObject gameOverPanel;
    //Num of bricks
    public int numberOfBricks;
    
    // Start is called before the first frame update
    void Start()
    {
        // Initializes number of lives
        livesText.text = "Lives: " + lives;

        // Initializes score
        scoreText.text = "Score: " + score;

        //Finds Gameobjects with the tag of brick and stores the total amount 
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Updates the lives of the player
    public void updateLives(int changeInLives)
    {
        lives += changeInLives;

        // Check for no lives left and trigger the end of the game
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        livesText.text = "Lives: " + lives;
    }

    // Updates the player's score
    public void updateScore(int points)
    {
        score += points;

        scoreText.text = "Score: " + score;
    }

    //Everytime a brick is destroyed
    public void UpdateNumberofBricks()
    {
        //Removes one from the numberOfbrick
        numberOfBricks--;
        
        //When the number of bricks is <=0
        if(numberOfBricks <= 0)
        {
            //For now just does gameover but will make it a load next level
            GameOver();

        }
    }


    void GameOver()
    {
        //Will be from false to true
        gameOver = true;
        gameOverPanel.SetActive(true);
    }
    //Play Again Button
    public void PlayAgain() 
    {
        SceneManager.LoadScene("SampleScene");
    
    
    }
    //Quit Button
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

}
