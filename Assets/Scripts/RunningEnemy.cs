using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class RunningEnemy : MonoBehaviour
    {
        public Rigidbody2D rigidbody;

        public bool isMoving = true;
        int direction = 1;
        public int speed;
        public int triggerNumber;
        public int fallSpeed;

        private void Start()
        {
            StartCoroutine(CheckXPosition());
        }
        void Update()
        {
            if (isMoving == false)
            {
                direction *= -1;
            }
            rigidbody.velocity = new Vector2(direction * speed, -10);
        }
        IEnumerator CheckXPosition()
        {
            while (true)
            {
                float previousXPosition = transform.position.x;
                yield return new WaitForSeconds(0.025f);
                float newXPosition = transform.position.x;
                if (newXPosition == previousXPosition)
                {
                    isMoving = false;
                }
                else
                {
                    isMoving = true;
                }
            }
        }
    }
}
