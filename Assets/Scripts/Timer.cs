using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace LastJourney
{
    public class Timer : MonoBehaviour
    {
        public GameManager gameManager;
        public Text timerDisplay;
        public int timer = 300;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(StartTimer());
            timerDisplay.text = timer.ToString();
        }

        private void Update()
        {
            if(timer <= 0)
            {
                StopCoroutine(StartTimer());
                timer = 0;
                gameManager.Restart();
            }
        }

        public void IncreaseTime(int increaseTime)
        {
            timer += increaseTime;
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