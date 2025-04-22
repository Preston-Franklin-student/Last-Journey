using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class FollowingEnemy : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public FollowingEnemy enemy;

        int decreaseTime = 10;
        int direction = 0;
        bool startMoving = false;
        bool leftWall = false;
        bool rightWall = false;

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
            if (triggerNumber == 0 && transform.position.x - player.transform.position.x <= 2 && startMoving == false)
            {
                direction = -1;
                startMoving = true;
            }

            if (triggerNumber == 0)
            {
                rigidbody.velocity = new Vector2(direction * speed, fallSpeed);

            }
            if (player.transform.position.x > transform.position.x && rightWall == false) direction = 1;
            if (player.transform.position.x < transform.position.x && leftWall == false) direction = -1;
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
            if (triggerNumber == 1 && other.gameObject.tag == "Ground" && enemy.direction == -1)
            {
                enemy.leftWall = true;
                enemy.direction = 0;
            }
            if (triggerNumber == 1 && other.gameObject.tag == "Ground" && enemy.direction == 1)
            {
                enemy.rightWall = true;
                enemy.direction = 0;
            }
            if (triggerNumber == 2 && other.gameObject.tag == "Ground") enemy.fallSpeed = 0f;
            if (triggerNumber == 3 && other.gameObject.tag == "Ground" && enemy.startMoving == true) enemy.fallSpeed = -0.1f;
        }
        //This function determines when the enemy is in midair and needs to fall
        //and when the enemy has fully risen out of the ground and needs to stop rising
        private void OnTriggerExit2D(Collider2D other)
        {
            if (triggerNumber == 1 && other.gameObject.tag == "Ground" && enemy.direction == 1) enemy.leftWall = false;
            if (triggerNumber == 1 && other.gameObject.tag == "Ground" && enemy.direction == -1) enemy.rightWall = false;
            if (triggerNumber == 2 && other.gameObject.tag == "Ground") enemy.fallSpeed = -5;
        }
    }
}
