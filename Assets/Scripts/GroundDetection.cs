using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class GroundDetection : MonoBehaviour
    {
        public Player player;

        public bool isFalling = true;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Ground") isFalling = false;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Ground") isFalling = true;
        }
    }
}