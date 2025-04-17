using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class GroundDetection : MonoBehaviour
    {
        public Player player;

        public bool isFalling = false;

        float previousYPosition;
        float newYPosition;
        private void Start()
        {
            player = GetComponent<Player>();
            StartCoroutine(CheckYPosition());
        }
        IEnumerator CheckYPosition()
        {
            while(true)
            {
                previousYPosition = player.transform.position.y;
                yield return new WaitForSeconds(0.025f);
                newYPosition = player.transform.position.y;
                if (Mathf.Abs(newYPosition - previousYPosition) < 0.05)
                {
                    isFalling = false;
                }
                else
                {
                    isFalling = true;
                }
            }
        }
    }
}