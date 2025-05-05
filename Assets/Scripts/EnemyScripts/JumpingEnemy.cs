using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class JumpingEnemy : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public JumpingEnemy enemy;

        public int decreaseTime = 10;
        float maxJumpHeight;

        public int triggerNumber;
        public int jumpHeight;
        public int jumpDelay;
        public float jumpForce = 4;
        public float fallSpeed;
        bool startJumping = false;

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
            if (triggerNumber == 2 && other.gameObject.tag == "Ground" && enemy.startJumping == true) enemy.fallSpeed = -0.1f;
        }
        IEnumerator StartEnemy()
        {
            while(true)
            {
                fallSpeed = 0;
                maxJumpHeight = transform.position.y + jumpHeight;
                while (rigidbody.transform.position.y < maxJumpHeight)
                {
                    transform.Translate(Vector2.up * Time.deltaTime * jumpForce);
                    yield return new WaitForSeconds(0.001f);
                }
                if (triggerNumber == 0 && startJumping == false) startJumping = true;
                fallSpeed = -5;
                yield return new WaitForSeconds(jumpDelay);
            }
        }
    }
}
