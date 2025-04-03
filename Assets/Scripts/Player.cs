using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        public int movementSpeed = 5;
        public int jumpSpeed = 5;

        Rigidbody2D rigidbody;

        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.right * horizontalInput * movementSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigidbody.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
            }
        }
    }
}
