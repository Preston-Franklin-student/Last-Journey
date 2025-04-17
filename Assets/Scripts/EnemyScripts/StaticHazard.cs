using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class StaticHazard : MonoBehaviour
    {
        int decreaseTime = 10;
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
