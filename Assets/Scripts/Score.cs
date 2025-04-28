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
        public HighscoreDatabase highscoreDatabase;

        public int score = 0;
        public int highScore = 0;
        public string level;

        void Start()
        {
            highScore = highscoreDatabase.FindHighScore(level);
            highScoreDisplay.text = "Highscore: " + highScore.ToString();
        }
        void OnDestroy()
        {
            highscoreDatabase.StoreHighScore(level, highScore);
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
