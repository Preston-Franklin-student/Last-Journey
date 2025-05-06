using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

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
        public int surfaceEnemyIndex;

        public int minSurfaceHazardAmount;
        public int maxSurfaceHazardAmount;
        public int surfaceHazardAmount;
        public int generateSurfaceHazard;
        public int maxSurfceHazardChance;

        int enemyCounter = 0;
        int clockCounter;
        public int maxClockCounter = 1;

        public GameObject blueClock;
        public GameObject greenClock;
        public GameObject redClock;
        public GameObject surfaceHazard;
        public Tilemap tilemap;
        public TileBase surfaceEnemySprite;
        public TileBase surfaceHazardSprite;

        //This function is used to generate clocks on demand as well as determining
        // what clock will be generated
        public void GenerateClock(float xposition, float yposition)
        {
            generator.transform.position = new Vector2(xposition, 0);
            float generatoryposition = generator.transform.position.y + yposition;
            generator.transform.position = new Vector2(xposition + 0.5f, generatoryposition + 1.5f);

            clockCounter = Random.Range(0, maxClockCounter);

            if (clockCounter < 5) Instantiate(blueClock, transform.position, transform.rotation);
            else if (clockCounter < 25) Instantiate(greenClock, transform.position, transform.rotation);
            else Instantiate(redClock, transform.position, transform.rotation);
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

        public void GenerateSurfaceEnemy(int xposition, int yposition)
        {
            Vector3Int position = new Vector3Int(xposition, yposition, 0);
            tilemap.SetTile(position, surfaceEnemySprite);

            generator.transform.position = new Vector2(xposition, 0);
            float generatoryposition = generator.transform.position.y + yposition;
            generator.transform.position = new Vector2(xposition + 0.5f, generatoryposition + 0.5f);
            Instantiate(enemies[surfaceEnemyIndex], transform.position, transform.rotation);
        }

        public void GenerateSurfaceHazard(int xposition, int yposition)
        {
            if (surfaceHazardAmount == 1) surfaceHazardAmount = Random.Range(minSurfaceHazardAmount, maxSurfaceHazardAmount);
            Vector3Int position = new Vector3Int(xposition, yposition, 0);
            tilemap.SetTile(position, surfaceHazardSprite);

            generator.transform.position = new Vector2(xposition, 0);
            float generatoryposition = generator.transform.position.y + yposition;
            generator.transform.position = new Vector2(xposition + 0.5f, generatoryposition + 0.5f);

            Instantiate(surfaceHazard, transform.position, transform.rotation);
            generateSurfaceHazard++;
            if (generateSurfaceHazard == surfaceHazardAmount)
            {
                generateSurfaceHazard = 0;
                surfaceHazardAmount = 1;
            }
        }
    }
}