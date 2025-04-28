using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class HighscoreDatabase : MonoBehaviour
    {
        public int FindHighScore(string level)
        {
            return PlayerPrefs.GetInt(level);
        }

        public void StoreHighScore(string level, int highscore)
        {
            PlayerPrefs.SetInt(level, highscore);
            PlayerPrefs.Save();
        }
    }
}
