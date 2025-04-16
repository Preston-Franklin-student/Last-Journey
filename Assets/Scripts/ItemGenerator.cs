using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class ItemGenerator : MonoBehaviour
    {
        public ItemGenerator generator;

        public List<GameObject> enemies = new List<GameObject>();

        public int minEnemyIndex;
        public int maxEnemyIndex;
        int targetEnemyIndex;

        public GameObject blueClock;

        //This function is used to generate clocks on demand as well as determining
        // what clock will be generated
        public void GenerateClock(float xposition, float yposition)
        {
            generator.transform.position = new Vector2(xposition, 0);
            float generatoryposition = generator.transform.position.y + yposition;
            generator.transform.position = new Vector2(xposition + 0.5f, generatoryposition + 1.6f);

            Instantiate(blueClock, transform.position, transform.rotation);
        }
        //This function is used to generate enemies on demand as well as determining
        //what enemy will be generated
        public void GenerateEnemy(float xposition, float yposition)
        {
            targetEnemyIndex = Random.Range(minEnemyIndex, maxEnemyIndex);
            generator.transform.position = new Vector2(xposition, 0);
            float generatoryposition = generator.transform.position.y + yposition;
            generator.transform.position = new Vector2(xposition + 0.5f, generatoryposition + 1.6f);

            Instantiate(enemies[targetEnemyIndex], transform.position, transform.rotation);
        }
    }

}