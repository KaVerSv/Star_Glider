using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManger : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    int score = 0;
    int highScore = 0;

    public static ScoreManger Instance { get { return _instance; } }
    private static ScoreManger _instance;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);

        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "Highscore: " + highScore.ToString();
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void addPoints(int points)
    {
        score += points;

        if (score > highScore)
        {
            PlayerPrefs.SetInt("highscore", score);
            highScore = score;
            highScoreText.text = "Highscore: " + highScore.ToString();
        }
        scoreText.text = "Score: " + score.ToString();
    }
}