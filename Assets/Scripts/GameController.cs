using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject GameOverText;
    public Text ScoreText;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(false);

        ScoreText.text = "SCORE:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOverText.activeSelf == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Main");
            }
            
        }
    }

    public void AddScore()
    {
        score += 100;

        ScoreText.text = "SCORE:" + score;
    }

    public void GameOver()
    {
        GameOverText.SetActive(true);
    }
}
