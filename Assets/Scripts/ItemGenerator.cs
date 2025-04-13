using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class ItemGenerator : MonoBehaviour
    {
        public ItemGenerator generator;

        public List<GameObject> enemies = new List<GameObject>();
        public GameObject blueClock;
        public void GenerateClock(float xposition, float yposition)
        {
            generator.transform.position = new Vector2(xposition, 0);
            float generatoryposition = generator.transform.position.y + yposition;
            generator.transform.position = new Vector2(xposition + 0.5f, generatoryposition + 1.6f);

            Instantiate(blueClock, transform.position, transform.rotation);
        }
        public void GenerateEnemy(float xposition, float yposition)
        {
            generator.transform.position = new Vector2(xposition, 0);
            float generatoryposition = generator.transform.position.y + yposition;
            generator.transform.position = new Vector2(xposition + 0.5f, generatoryposition + 1.6f);

            Instantiate(enemies[0], transform.position, transform.rotation);
        }
    }

}