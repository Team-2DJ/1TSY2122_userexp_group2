using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    
    // Start is called before the first frame update
    void Start()
    {
        // Initializes number of lives
        livesText.text = "Lives: " + lives;

        // Initializes score
        scoreText.text = "Score: " + score;
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

        livesText.text = "Lives: " + lives;
    }

    // Updates the player's score
    public void updateScore(int points)
    {
        score += points;

        scoreText.text = "Score: " + score;
    }
}
