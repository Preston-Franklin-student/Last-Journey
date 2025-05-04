using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace LastJourney
{
    public class Timer : MonoBehaviour
    {
        public GameManager gameManager;
        public Text timerDisplay;
        public Score score;
        public Player player;
        public GameObject player2;

        public int timer = 300;
        public int levelIndex;
        public bool destroyPlayer = false;
        // Start is called before the first frame update
        void Start()
        {
            gameManager = FindFirstObjectByType<GameManager>();
            StartCoroutine(StartTimer());
            timerDisplay.text = timer.ToString();
        }

        private void Update()
        {
            if(timer <= 0 && destroyPlayer == false)
            {
                StopCoroutine(StartTimer());
                timer = 0;
                timerDisplay.text = timer.ToString();
                destroyPlayer = true;
                DestroyPlayer();
            }
        }
        private void DestroyPlayer()
        {
            player.PlayDeathEffect();
            player2.SetActive(false);
            Invoke("GameOver", 1);
        }
        private void GameOver()
        {
            gameManager.TransferLevelIndex(levelIndex, score.score, score.highScore);
            gameManager.GameOver();
        }

        public void IncreaseTime(int increaseTime)
        {
            timer += increaseTime;
            timerDisplay.text = timer.ToString();
        }

        public void DecreaseTime(int decreaseTime)
        {
            timer -= decreaseTime;
            timerDisplay.text = timer.ToString();
        }
        IEnumerator StartTimer()
        {
            while (timer > 0)
            {
                yield return new WaitForSeconds(1);
                timer--;
                timerDisplay.text = timer.ToString();
            }
        }
    }

}