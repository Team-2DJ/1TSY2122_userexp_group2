using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 

public class StartMenuScript : MonoBehaviour
{
    // same idea, let's avoid hardcoded code
    [SerializeField] string startGameScene;
    [SerializeField] TextMeshProUGUI highScoreText;

    void Start()
    {
        // if High Score name != null then run code, else, text writes "no high score" 
        if (PlayerPrefs.GetString("HIGHSCORENAME") != "")
            highScoreText.text = "High Score by " + PlayerPrefs.GetString("HIGHSCORENAME") + ": " + PlayerPrefs.GetInt("HIGHSCORE");
        else
            highScoreText.text = "No High Score";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startGameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
