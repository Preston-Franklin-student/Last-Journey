using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class Player : MonoBehaviour
    {
        public float jumpForce = 4;
        public Rigidbody2D rigidbody;

        public Camera camera;
        public Player player;
        public GameObject playerDeathEffect;

        float maxJumpHeight;
        public float baseJumpHeight;
        public float restrictedJumpHeight = 0;
        public int fallSpeed = -10;
        public float restrictedFallSpeed;
        public bool isJumping = false;
        public bool isFalling = true;
        public int speed = 5;
        public float restrictedSpeed = 1;
        public int hazardousSurfaceCounter = 0;
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        public void PlayDeathEffect()
        {
            Instantiate(playerDeathEffect, transform.position, Quaternion.identity);
        }
        private void Update()
        {
                float horizontalInput = Input.GetAxis("Horizontal");

                if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && player.isFalling == false && isJumping == false)
                {
                    StartCoroutine(PlayerJump());
                }
                if (player.isFalling == true && isJumping == false)
                {
                    fallSpeed = -10;
                }
                else
                {
                    fallSpeed = 0;
                }
                rigidbody.velocity = new Vector2(horizontalInput * speed * restrictedSpeed, fallSpeed * restrictedFallSpeed);

                if (transform.position.x <= -0.46 && horizontalInput != 1)
                {
                    rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
                    if (transform.position.x <= -0.46 && horizontalInput == 0)
                    {
                        rigidbody.velocity = new Vector2(1f, rigidbody.velocity.y);
                    }
                }

                if (transform.position.x >= 200.44 && horizontalInput != -1)
                {
                    rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
                    if (transform.position.x >= 200.44 && horizontalInput == 0)
                    {
                        rigidbody.velocity = new Vector2(-1f, rigidbody.velocity.y);
                    }
                }
                if(transform.position.y < 0)
                {
                    transform.position = new Vector2(0, 3.5f);
                    rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
                }
        }

        IEnumerator PlayerJump()
        {
            fallSpeed = 0;
            isJumping = true;
            maxJumpHeight = rigidbody.transform.position.y + (baseJumpHeight - restrictedJumpHeight);
            while (rigidbody.transform.position.y < maxJumpHeight)
            {
                transform.Translate(Vector2.up * Time.deltaTime * jumpForce);
                yield return new WaitForSeconds(0.001f);
            }
            fallSpeed = -10;
            isJumping = false;
        }
    }
}