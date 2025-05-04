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
        public int fallSpeed = -10;
        public bool isJumping = false;
        public bool isFalling = true;
        public int speed = 5;
        public int triggerNumber;
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
            if(triggerNumber == 0)
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
                rigidbody.velocity = new Vector2(horizontalInput * speed, fallSpeed);

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
        }

        IEnumerator PlayerJump()
        {
            fallSpeed = 0;
            isJumping = true;
            maxJumpHeight = rigidbody.transform.position.y + 3;
            while (rigidbody.transform.position.y < maxJumpHeight)
            {
                transform.Translate(Vector2.up * Time.deltaTime * jumpForce);
                yield return new WaitForSeconds(0.001f);
            }
            fallSpeed = -10;
            isJumping = false;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
 
            if (triggerNumber == 1 && other.gameObject.tag == "Ground") player.isFalling = false;
        }
        //This function determines when the enemy is in midair and needs to fall
        //and when the enemy has fully risen out of the ground and needs to stop rising
        private void OnTriggerExit2D(Collider2D other)
        {
            if (triggerNumber == 1 && other.gameObject.tag == "Ground") player.isFalling = true;
        }
    }
}