using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Text score;
    public static float scoreCount;
    public GameObject character;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        score.text = scoreCount.ToString();
        isDead();
    }
    
    void isDead()
    {
        if(character.transform.position.y < -10f)
        {
            if(scoreCount > PlayerPrefs.GetFloat("HighScore", 0))
            {
                PlayerPrefs.SetFloat("HighScore", scoreCount);
            }
            SceneManager.LoadScene(2);
        }
    }
    
}
