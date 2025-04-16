using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class RunningEnemy : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public RunningEnemy enemy;

        int decreaseTime = 10;
        int direction = 0;
        bool startMoving = false;

        public int speed;
        public int triggerNumber;
        public float fallSpeed;

        void Start()
        {
            direction = 0;
        }
        //This function will have the enemy start moving when the player gets close enough
        void Update()
        {
            Player player = FindFirstObjectByType<Player>();
            if (triggerNumber == 0 && transform.position.x - player.transform.position.x <= 15 && startMoving == false)
            {
                direction = -1; 
                startMoving = true;
            }

                if (triggerNumber == 0)
            {
                rigidbody.velocity = new Vector2(direction * speed, fallSpeed);

            }
        }
        //This function is used by different triggers to prevent the player from
        //clipping through the ground
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (triggerNumber == 0 && other.gameObject.tag == "Player")
            {
                Timer timer = FindFirstObjectByType<Timer>();
                timer.DecreaseTime(decreaseTime);
            }
            if (triggerNumber == 1 && other.gameObject.tag == "Ground") enemy.direction *= -1;
            if (triggerNumber == 2 && other.gameObject.tag == "Ground") enemy.fallSpeed = 0f;
            if (triggerNumber == 3 && other.gameObject.tag == "Ground") enemy.fallSpeed = 0.1f; 
        }
        //This function raises the enemy out of the ground if it sinks into the ground
        private void OnCollisionStay2D(Collision2D other)
        {
            if (triggerNumber == 3 && other.gameObject.tag == "Ground") enemy.fallSpeed = 25;
        }
        //This function determines when the enemy is in midair and needs to fall
        //and when the enemy has fully risen out of the ground and needs to stop rising
        private void OnTriggerExit2D(Collider2D other)
        {
            if (triggerNumber == 2 && other.gameObject.tag == "Ground") enemy.fallSpeed = -5;
            if (triggerNumber == 4 && other.gameObject.tag == "Ground" && enemy.fallSpeed == 0.1f) enemy.fallSpeed = 0f;
        }
    }
}
