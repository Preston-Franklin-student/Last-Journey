using System.Collections;
using System.Collections.Generic;
using LastJourney;
using UnityEngine;

namespace TowerDefense
{
    public class Camera : MonoBehaviour
    {
        public Player player;

        // Update is called once per frame
        void Update()
        {
            if(player.transform.position.x <= 7)
            {
                transform.position = new Vector3(7, 5, -10);
            }
            else if(player.transform.position.x >= 192)
            {
                transform.position = new Vector3(192, 5, -10);
            }
            else
            {
                transform.position = new Vector3(player.transform.position.x, 5, -10);
            }
        }
    }
}
