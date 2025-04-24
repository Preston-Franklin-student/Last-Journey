using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class LevelSelect : MonoBehaviour
    {
        public LevelSelect levelSelect;
        public GameObject[] levels;
        public int levelIndex;
        public int currentLevelIndex = 1;
        public bool levelButton;

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < levels.Length; i++)
            {
                if (i == currentLevelIndex) levels[i].SetActive(true);
                else levels[i].SetActive(false);
            }
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
