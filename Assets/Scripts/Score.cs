using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LastJourney
{
    public class Score : MonoBehaviour
    {
        public Text scoreDisplay;
        public Text highScoreDisplay;

        public int score = 0;
        public int highScore = 0;

        void Start()
        {
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            highScoreDisplay.text = "Highscore: " + highScore.ToString();
        }
        void OnDestroy()
        {
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        public void GainScore()
        {
            score++;
            if (score > highScore)
            {
                scoreDisplay.text = "Score: " + score.ToString();
                highScore = score;
                highScoreDisplay.text = "New highscore";
            }
            else
            {
                scoreDisplay.text = "Score: " + score.ToString();
            }
        }
    }
}
