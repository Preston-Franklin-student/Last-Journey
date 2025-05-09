using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class PlayerJump : MonoBehaviour
    {
        Player player;
        // Start is called before the first frame update
        void Start()
        {
            player = FindFirstObjectByType<Player>();
        }

        // Update is called once per frame
        void Update()
        {

            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && player.isFalling == false && player.isJumping == false)
            {
                StartCoroutine(Jump());
            }
        }

        IEnumerator Jump()
        {
            player.fallSpeed = 0;
            player.isJumping = true;
            player.maxJumpHeight = player.rigidbody.transform.position.y + (player.baseJumpHeight - player.restrictedJumpHeight);
            while (player.rigidbody.transform.position.y < player.maxJumpHeight)
            {
                transform.Translate(Vector2.up * Time.deltaTime * player.jumpForce);
                yield return new WaitForSeconds(0.001f);
            }
            player.fallSpeed = -10;
            player.isJumping = false;
        }
    }
}