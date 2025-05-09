using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class Camera : MonoBehaviour
    {
        public Player player;

        float defaultWidth = 20f;
        private void Start()
        {
            GetComponent<Camera>();
            float aspectRatio = (float)Screen.width / Screen.height;
            UnityEngine.Camera.main.orthographicSize = defaultWidth / aspectRatio / 1.65f;
        }
        // Update is called once per frame
        void Update()
        {
            if(player.transform.position.x <= 11.21)
            {
                transform.position = new Vector3(11.21f, 5.67f, -10);
            }
            else if(player.transform.position.x >= 188.53)
            {
                transform.position = new Vector3(188.53f, 5.67f, -10);
            }
            else
            {
                transform.position = new Vector3(player.transform.position.x, 5.67f, -10);
            }
        }
    }
}
