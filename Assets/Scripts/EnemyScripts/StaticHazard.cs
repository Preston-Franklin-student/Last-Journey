using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class StaticHazard : MonoBehaviour
    {
        public int decreaseTime = 2;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag == "Player")
            {
                Timer timer = FindFirstObjectByType<Timer>();
                timer.DecreaseTime(decreaseTime);
            }
        }
    }
}
