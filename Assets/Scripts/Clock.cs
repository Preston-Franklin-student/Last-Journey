using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LastJourney
{
    public class Clock : MonoBehaviour
    {
        public int increaseTime;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Timer timer = FindFirstObjectByType<Timer>();
                timer.IncreaseTime(increaseTime);
                Destroy(gameObject);
            }
        }
    }
}
