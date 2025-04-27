using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace LastJourney
{
    public class ViewScore : MonoBehaviour
    {
        public Text score;
        public Text highScore;
        // Start is called before the first frame update
        void Start()
        {
            GameManager gameManager = FindFirstObjectByType<GameManager>();
            score.text = "Score: " + gameManager.score.ToString();
            highScore.text = "Highscore: " + gameManager.highScore.ToString();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}