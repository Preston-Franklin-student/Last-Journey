using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class RunningEnemy : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public RunningEnemy enemy;
        public Timer timer;

        int direction = 1;
        int decreaseTime = 5;

        public int speed;
        public int triggerNumber;
        public float fallSpeed;

        private void Start()
        {
        }
        void Update()
        {
            if (triggerNumber == 0)
            {
                rigidbody.velocity = new Vector2(direction * speed, fallSpeed);
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (triggerNumber == 0 && other.gameObject.tag == "Player")
            {
                Timer timer = FindFirstObjectByType<Timer>();
                timer.DecreaseTime(decreaseTime);
            }
            if (triggerNumber == 1 && other.gameObject.tag == "Ground") enemy.direction *= -1;
            if (triggerNumber == 2 && other.gameObject.tag == "Ground") enemy.fallSpeed = 0f;
            if (triggerNumber == 4 && other.gameObject.tag == "Ground" && enemy.fallSpeed == 0) enemy.fallSpeed = 0.1f; 
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (triggerNumber == 2 && other.gameObject.tag == "Ground") enemy.fallSpeed = -5;
            if (triggerNumber == 3 && other.gameObject.tag == "Ground" && enemy.fallSpeed == 0.1f) enemy.fallSpeed = 0;
        }
    }
}
