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
        public int score;
        public int highScore;
        public int chosenLevel = 0;
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
        public void TutorialScene()
        {
            SceneManager.LoadScene(2);
        }
        public void TitleScreen()
        {
            SceneManager.LoadScene(0);
        }
        public void TransferLevelIndex(int levelNumber, int score, int highScore)
        {
            GameManager.instance.levelIndex = levelNumber;
            instance.score = score;
            instance.highScore = highScore;
        }

        public void GameOver()
        {
            SceneManager.LoadScene(1);
        }

        public void Restart()
        {
            SceneManager.LoadScene(levelIndex);
        }

        public void LoadChosenLevel()
        {
            LevelSelect levelSelect = FindFirstObjectByType<LevelSelect>();
            chosenLevel = levelSelect.currentLevelIndex + 3;
            print(chosenLevel);
            SceneManager.LoadScene(chosenLevel);
        }
    }
}
