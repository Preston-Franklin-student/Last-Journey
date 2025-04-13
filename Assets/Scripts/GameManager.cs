using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LastJourney
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        void Awake()
        {
            if (instance)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadForestLevel()
        {
            SceneManager.LoadScene(1);
        }
    }
}
