using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class RunningEnemy : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public RunningEnemy enemy;

        public bool isMoving = true;
        int direction = 1;
        public int speed;
        public int triggerNumber;
        public int fallSpeed;

        private void Start()
        {
        }
        void Update()
        {
            if(triggerNumber == 0)
            {
                if (isMoving == false)
                {
                    direction *= -1;
                }
                rigidbody.velocity = new Vector2(direction * speed, -10);
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (triggerNumber == 1 && other.gameObject.tag == "Ground")
            {
                enemy.direction *= -1;
            }
        }
    }
}
