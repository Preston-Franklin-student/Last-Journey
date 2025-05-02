using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LastJourney
{
    public class Clock : MonoBehaviour
    {
        public GameObject particleEffect;
        public int increaseTime;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Timer timer = FindFirstObjectByType<Timer>();
                timer.IncreaseTime(increaseTime);
                Instantiate(particleEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
