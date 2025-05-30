using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class FollowingEnemy : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public FollowingEnemy enemy;

        public int decreaseTime = 10;
        int direction = 0;
        public bool startMoving = false;
        public bool leftWall = false;
        public bool rightWall = false;
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
            Timer timer = FindFirstObjectByType<Timer>();
            if(timer.destroyPlayer == false)
            {
                if (triggerNumber == 0 && transform.position.x - player.transform.position.x <= 3 && startMoving == false)
                {
                    direction = -1;
                    startMoving = true;
                }
                if (triggerNumber == 0)
                {
                    if (player.transform.position.x > transform.position.x && leftWall == true) leftWall = false;
                    if (player.transform.position.x < transform.position.x && rightWall == true) rightWall = false;
                    if (Mathf.Abs(player.transform.position.x - transform.position.x) < 0.1f) direction = 0;
                    else if (player.transform.position.x < transform.position.x - 3 && leftWall == false && startMoving == true) direction = -1;
                    else if (player.transform.position.x > transform.position.x + 3 && rightWall == false && startMoving == true) direction = 1;
                }
            }
            if (triggerNumber == 0)
            {
                rigidbody.velocity = new Vector2(direction * speed, fallSpeed);

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
            if (triggerNumber == 2 && other.gameObject.tag == "Ground") enemy.fallSpeed = 0f;
            if (triggerNumber == 3 && other.gameObject.tag == "Ground" && enemy.startMoving == true) enemy.fallSpeed = -0.1f;
            if (triggerNumber == 1 && other.gameObject.tag == "Ground")
            {
                enemy.direction = 0;
                enemy.leftWall = true;
                enemy.rightWall = true;
            }
        }
        //This function determines when the enemy is in midair and needs to fall
        //and when the enemy has fully risen out of the ground and needs to stop rising
        private void OnTriggerExit2D(Collider2D other)
        {
            if (triggerNumber == 2 && other.gameObject.tag == "Ground") enemy.fallSpeed = -5;
        }
    }
}
