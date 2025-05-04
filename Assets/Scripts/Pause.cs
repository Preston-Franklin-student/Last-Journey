using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class Pause : MonoBehaviour
    {
        public GameObject pauseMenu;
        public bool isPaused = false;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
            {
                isPaused = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
