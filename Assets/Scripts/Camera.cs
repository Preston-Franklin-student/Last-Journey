using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class Camera : MonoBehaviour
    {
        public Player player;

        // Update is called once per frame
        void Update()
        {
            if(player.transform.position.x <= 9.04)
            {
                transform.position = new Vector3(9.04f, 5.67f, -10);
            }
            else if(player.transform.position.x >= 190.98)
            {
                transform.position = new Vector3(190.98f, 5.67f, -10);
            }
            else
            {
                transform.position = new Vector3(player.transform.position.x, 5.67f, -10);
            }
        }
    }
}
