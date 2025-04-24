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
            if(player.transform.position.x <= 7.8)
            {
                transform.position = new Vector3(7.8f, 5.67f, -10);
            }
            else if(player.transform.position.x >= 192.2)
            {
                transform.position = new Vector3(192.2f, 5.67f, -10);
            }
            else
            {
                transform.position = new Vector3(player.transform.position.x, 5.67f, -10);
            }
        }
    }
}
