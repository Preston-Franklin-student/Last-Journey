using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class Player : MonoBehaviour
    {
        public Rigidbody2D rigidbody;

        public int speed = 7;
        private Vector2 playerMovement;

        private void OnAwake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            playerMovement = new Vector2(horizontalInput * speed, -5);

            rigidbody.velocity = playerMovement;
        }
    }
}
