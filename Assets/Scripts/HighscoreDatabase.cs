using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class HighscoreDatabase : MonoBehaviour
    {
        public int[] highScores;

        public int FindHighScore(string level)
        {
            highScores[0] = PlayerPrefs.GetInt(level, 0);
            return 1;
        }
    }
}
