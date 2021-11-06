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
    public TextMeshProUGUI highScoreText;
    public TMP_InputField highScoreInput;
    


    //Gameover is start false
    public bool gameOver;
    //Holds the gameover panel
    public GameObject gameOverPanel;
    //Holds the loading level panel
    public GameObject loadLevelPanel;
    //Num of bricks
    public int numberOfBricks;

    //List of levels
    public Transform[] levels;
    //Current Level
    public int currentLevelIndex;
   
    // Start is called before the first frame update
    void Start()
    {
        // Initializes number of lives
        livesText.text = "Lives: " + lives;

        // Initializes score
        scoreText.text = "Score: " + score;

        // Finds Gameobjects with the tag of brick and stores the total amount 
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
            //When index is equal or greater than to the last level
            if (currentLevelIndex >= levels.Length - 1)
            {
                //For now just does gameover but will make it a load next level
                GameOver();
            } else {
                //Makes loading level visible
                loadLevelPanel.SetActive(true);
                //Changes text name
                loadLevelPanel.GetComponentInChildren<Text> ().text = "Level " + (currentLevelIndex + 2);

                //Freezes or gives time, like a loading screen, so that it won't go to the next level instantly
                gameOver = true;
                //Invoke the function loadLevel and plays it after a set amount of time 
                Invoke("LoadLevel", 3f);
            }
            

        }
    }

    void LoadLevel()
    {
        //add to currentlevelindex
        currentLevelIndex++;
        //Instatnatiate the next level
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        //Looks at the number of bricks
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;

        //In the UpdateNumberofBricks() gameOver becomes true for a loading screen
        //This removes the loading screen
        gameOver = false;
        //Makes loading level invisible
        loadLevelPanel.SetActive(false);

    }

    void GameOver()
    {
        //Will be from false to true
        gameOver = true;
        gameOverPanel.SetActive(true);

        // Initializes the high score
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");

        // Overwrites the score when high score is reached
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HIGHSCORE", score);
            highScoreText.text = "New High Score!" + "\n" + "Enter Your Name Below.";
            highScoreInput.gameObject.SetActive(true);
        }
        // Displays high score only (If player didn't reach the high score)
        else
        {
            highScoreText.text = PlayerPrefs.GetString("HIGHSCORENAME") + "'s" + " High Score was " + highScore + "\n" + "Can you beat it?";
        }
    }

    // When player is done inputting the name
    public void NewHighScore()
    {
        string highScoreName = highScoreInput.text;
        PlayerPrefs.SetString("HIGHSCORENAME", highScoreName);
        highScoreInput.gameObject.SetActive(false);
        highScoreText.text = "Congratulations " + highScoreName + "\n" + "Your New High Score is " + score;
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
