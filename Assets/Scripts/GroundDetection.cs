using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class GroundDetection : MonoBehaviour
    {
        Player player;
        // Start is called before the first frame update
        void Start()
        {
            player = FindFirstObjectByType<Player>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Ground") player.isFalling = false;
            if (other.gameObject.tag == "Ground" && player.hazardousSurfaceCounter == 0)
            {
                player.restrictedJumpHeight = 0;
                player.restrictedFallSpeed = 1;
                player.restrictedSpeed = 1;
            }
        }
        //This function determines when the enemy is in midair and needs to fall
        //and when the enemy has fully risen out of the ground and needs to stop rising
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Ground") player.isFalling = true;
        }
    }
}
