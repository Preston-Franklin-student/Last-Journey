using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class LevelSelect : MonoBehaviour
    {
        public LevelSelect levelSelect;
        public GameObject gameObject;
        public int levelIndex;
        int currentLevelIndex = 1;
        public bool levelButton;

        // Update is called once per frame
        void Update()
        {
            if (levelButton == true && levelIndex == levelSelect.currentLevelIndex) gameObject.SetActive(true);
            else if(levelButton == false) gameObject.SetActive(false);
        }

        public void IncreaseIndex()
        {
            levelSelect.currentLevelIndex++;
        }

        public void DecreaseIndex()
        {
            levelSelect.currentLevelIndex--;
        }
    }
}
