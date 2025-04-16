using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class JumpingEnemy : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public RunningEnemy enemy;

        int decreaseTime = 10;
        float maxJumpHeight;

        public int triggerNumber;
        public float jumpForce;
        public float fallSpeed;

        //This function will have the enemy start moving when the player gets close enough
        private void Start()
        {
            StartCoroutine(StartEnemy());
        }

        private void Update()
        {
            rigidbody.velocity = new Vector2(0, fallSpeed);
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
            if (triggerNumber == 4 && other.gameObject.tag == "Ground" && enemy.fallSpeed == 0.1f) enemy.fallSpeed = 0f;
        }

        IEnumerator StartEnemy()
        {
            fallSpeed = 0;
            maxJumpHeight = transform.position.y + 3;
            while (rigidbody.transform.position.y < maxJumpHeight)
            {
                transform.Translate(Vector2.up * Time.deltaTime * jumpForce);
                yield return new WaitForSeconds(0.001f);
            }
            fallSpeed = -5;
        }
    }
}
