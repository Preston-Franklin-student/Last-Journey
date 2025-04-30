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
            if(levelSelect.currentLevelIndex < 1) levelSelect.currentLevelIndex++;
        }

        public void DecreaseIndex()
        {
            if(levelSelect.currentLevelIndex > 0) levelSelect.currentLevelIndex--;
        }
    }
}
