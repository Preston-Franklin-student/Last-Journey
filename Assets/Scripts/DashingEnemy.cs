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
        bool destroy = false;

        public float speed;
        public int triggerNumber;

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
                rigidbody.velocity = new Vector2(direction * speed, 0);
                transform.Rotate(0, 0, 5);
            }
            if (destroy == true) Destroy(gameObject);
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
            if (triggerNumber == 1 && other.gameObject.tag == "Ground") enemy.destroy = true;
        }
    }
}
