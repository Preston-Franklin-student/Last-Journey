using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class DashingEnemy : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public DashingEnemy enemy;

        public int decreaseTime = 10;
        int direction = 0;
        public bool startMoving = false;
        public bool canDash = false;

        public float speed;
        public int triggerNumber;
        public float rotation;

        void Start()
        {
            direction = 0;
        }
        //This function will have the enemy start moving when the player gets close enough
        void Update()
        {
            Player player = FindFirstObjectByType<Player>();
            if (triggerNumber == 0 && transform.position.x - player.transform.position.x <= 10 && startMoving == false)
            {
                direction = -1;
                startMoving = true;
            }
            if (direction == -1 && triggerNumber == 0 && canDash == true)
            {
                transform.Rotate(0, 0, rotation);
            }
            if (direction == 1 && triggerNumber == 0 && canDash == true)
            {
                transform.Rotate(0, 0, rotation * -1);
            }
            if (triggerNumber == 0)
            {
                rigidbody.velocity = new Vector2(direction * speed, 0);

            }
        }
        //This function is used by different triggers to prevent the player from
        //clipping through the ground and to allow the enemy to damage the player
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (triggerNumber == 0 && other.gameObject.tag == "Player")
            {
                Timer timer = FindFirstObjectByType<Timer>();
                timer.DecreaseTime(decreaseTime);
            }
            if (triggerNumber == 1 && other.gameObject.tag == "Ground" && enemy.canDash == false) enemy.direction *= -1;
            if (triggerNumber == 2 && other.gameObject.tag == "Ground") enemy.canDash = false;
            if (triggerNumber == 3 && other.gameObject.tag == "Ground" && enemy.canDash == true) enemy.speed = 0.1f;
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (triggerNumber == 2 && other.gameObject.tag == "Ground") enemy.canDash = true;
        }
    }
}
