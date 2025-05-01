using LastJourney;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class LevelSelector : MonoBehaviour
    {
        public LevelSelect levelSelect;
        public void IncreaseIndex()
        {
            if(levelSelect.currentLevelIndex < levelSelect.maxLevelIndex) levelSelect.currentLevelIndex++;
        }

        public void DecreaseIndex()
        {
            if(levelSelect.currentLevelIndex > 0) levelSelect.currentLevelIndex--;
        }
    }
}
