using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class HazardousSurface : MonoBehaviour
    {
        public Player player;

        public void Start()
        {
            player = FindFirstObjectByType<Player>();
        }
        public void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag == "Player")
            {
                if (player.hazardousSurfaceCounter == 0) player.restrictedSpeed = 0.2f;
                player.hazardousSurfaceCounter += 1;
                player.restrictedJumpHeight = 2f;
                player.restrictedFallSpeed = 0.2f;
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                player.hazardousSurfaceCounter -= 1;
                if(player.hazardousSurfaceCounter == 0) player.restrictedSpeed = 1;
                if (player.isJumping == false) player.restrictedJumpHeight = 0;
                if( player.isJumping == false) player.restrictedFallSpeed = 1;
            }
        }
    }
}
