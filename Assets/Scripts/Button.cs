using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class Button : MonoBehaviour
    {
        GameManager gameManager;
        // Start is called before the first frame update
        void Start()
        {
            gameManager = FindFirstObjectByType<GameManager>();
        }
        public void TitleScreen()
        {
            gameManager.TitleScreen();
        }
        public void RestartLevel()
        {
            gameManager.Restart();
        }
        public void LoadChosenLevel()
        {
            gameManager.LoadChosenLevel();
        }
    }
}
