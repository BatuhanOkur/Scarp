using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text highScore,yourScore;
   

     void Start()
    {
        yourScore.text = Manager.scoreCount.ToString();
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }

     void Update()
    {
        RestartGame();
        QuitGame();
    }

    void RestartGame()
    {
        if (Input.GetKeyDown("space"))
        {
            Manager.scoreCount = 0;
            SceneManager.LoadScene(1);
        }
    }

    void QuitGame()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }



}
