using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class Player : MonoBehaviour
    {
        public float jumpForce = 4;
        public Rigidbody2D rigidbody;

        public GroundDetection detection;
        public Camera camera;

        float maxJumpHeight;
        bool isJumping = false;

        public int speed = 7;
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && detection.isFalling == false && isJumping == false)
            {
                StartCoroutine(PlayerJump());
            }
            if(isJumping == true)
            {
                rigidbody.velocity = new Vector2(horizontalInput * speed, 0);
            }
            else
            {
                rigidbody.velocity = new Vector2(horizontalInput * speed, -10);
            }
            if (transform.position.x <= -0.55 && horizontalInput != 1)
            {
                rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
            }
            if (transform.position.x >= 199.55 && horizontalInput != -1)
            {
                rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
            }
        }

        IEnumerator PlayerJump()
        {
            isJumping = true;
            maxJumpHeight = rigidbody.transform.position.y + 3;
            while (rigidbody.transform.position.y < maxJumpHeight)
            {
                transform.Translate(Vector2.up * Time.deltaTime * jumpForce);
                yield return new WaitForSeconds(0.001f);
            }
            isJumping = false;
        }
    }
}