using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LastJourney
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public int levelIndex;
        void Awake()
        {
            if (instance)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void TitleScreen()
        {
            SceneManager.LoadScene(0);
        }
        public void TransferLevelIndex(int levelNumber)
        {
            GameManager.instance.levelIndex = levelNumber;
        }

        public void GameOver()
        {
            SceneManager.LoadScene(1);
        }

        public void Restart()
        {
            SceneManager.LoadScene(levelIndex);
        }

        public void LoadForestLevel()
        {
            SceneManager.LoadScene(2);
        }
    }
}
