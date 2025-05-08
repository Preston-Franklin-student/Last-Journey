using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class WallCollider : MonoBehaviour
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

        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Ground" && player.restrictedFallSpeed != 1) player.restrictedFallSpeed = 1;
        }
    }
}
