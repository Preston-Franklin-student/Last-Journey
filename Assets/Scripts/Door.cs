using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class Door : MonoBehaviour
    {
        public LevelGenerator generator;
        public Score score;

        public bool useDoor = false;

        private void Update()
        {
            if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && useDoor == true)
            {
                score.GainScore();
                generator.NewSection();
            }
        }
            void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player")) useDoor = true;
        }
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player")) useDoor = false;
        }
    }
}