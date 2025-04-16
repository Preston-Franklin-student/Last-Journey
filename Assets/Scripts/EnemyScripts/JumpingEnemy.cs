using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class JumpingEnemy : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public JumpingEnemy enemy;

        int decreaseTime = 10;
        float maxJumpHeight;

        public int triggerNumber;
        public float jumpForce = 4;
        public float fallSpeed;

        //This function will have the enemy start moving when the player gets close enough
        private void Start()
        {
            if(triggerNumber == 0) StartCoroutine(StartEnemy());
        }

        private void Update()
        {
            if(triggerNumber == 0)rigidbody.velocity = new Vector2(0, fallSpeed);
        }

        //This function is used by different triggers to prevent the player from
        //clipping through the ground
        //
        //This function is also used to damage the player
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (triggerNumber == 0 && other.gameObject.tag == "Player")
            {
                Timer timer = FindFirstObjectByType<Timer>();
                timer.DecreaseTime(decreaseTime);
            }
            if (triggerNumber == 1 && other.gameObject.tag == "Ground") enemy.fallSpeed = 0f;
            if (triggerNumber == 2 && other.gameObject.tag == "Ground") enemy.fallSpeed = 0.1f;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (triggerNumber == 2 && other.gameObject.tag == "Ground" && enemy.fallSpeed > 0) enemy.fallSpeed = 0;
        }
        IEnumerator StartEnemy()
        {
            while(true)
            {
                fallSpeed = 0;
                maxJumpHeight = transform.position.y + 4;
                while (rigidbody.transform.position.y < maxJumpHeight)
                {
                    transform.Translate(Vector2.up * Time.deltaTime * jumpForce);
                    yield return new WaitForSeconds(0.001f);
                }
                fallSpeed = -5;
                yield return new WaitForSeconds(3);
            }
        }
    }
}
