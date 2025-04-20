using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class ItemGenerator : MonoBehaviour
    {
        public ItemGenerator generator;
        public Score score;

        public List<GameObject> enemies = new List<GameObject>();

        public int minEnemyIndex;
        public int maxEnemyIndex;
        public int spikeIndex;
        public int minSpikeAmount;
        public int maxSpikeAmount;
        public int spikeAmount;
        public int generateSpike;
        public int targetEnemyIndex;
        public int spikeCooldown;
        int enemyCounter = 0;

        public GameObject blueClock;

        //This function is used to generate clocks on demand as well as determining
        // what clock will be generated
        public void GenerateClock(float xposition, float yposition)
        {
            generator.transform.position = new Vector2(xposition, 0);
            float generatoryposition = generator.transform.position.y + yposition;
            generator.transform.position = new Vector2(xposition + 0.5f, generatoryposition + 1.5f);

            Instantiate(blueClock, transform.position, transform.rotation);
        }
        //This function is used to generate enemies on demand as well as determining
        //what enemy will be generated
        public void GenerateEnemy(float xposition, float yposition)
        {
            generator.transform.position = new Vector2(xposition, 0);
            float generatoryposition = generator.transform.position.y + yposition;
            generator.transform.position = new Vector2(xposition + 0.5f, generatoryposition + 1.5f);

                Instantiate(enemies[targetEnemyIndex], transform.position, transform.rotation);
                if (spikeCooldown == 10) spikeCooldown = 0;
                else if(spikeCooldown != 0) spikeCooldown++;
        }

        public void GenerateSpike(float xposition, float yposition)
        {
            generator.transform.position = new Vector2(xposition, 0);
            float generatoryposition = generator.transform.position.y + yposition;
            generator.transform.position = new Vector2(xposition + 0.5f, generatoryposition + 1.5f);

            if (spikeAmount == 1) spikeAmount = Random.Range(minSpikeAmount, maxSpikeAmount);
            Instantiate(enemies[spikeIndex], transform.position, transform.rotation);
            generateSpike++;
            if (generateSpike == spikeAmount)
            {
                generateSpike = 0;
                spikeAmount = 1;
                spikeCooldown++;
            }
        }
    }
}