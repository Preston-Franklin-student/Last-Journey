using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

namespace LastJourney
{
    public class LevelGenerator : MonoBehaviour
    {
        public Player player;
        public Score score;
        public Tilemap tilemap;
        public TileBase tileSurface;
        public TileBase tileGround;
        public ItemGenerator generator;

        public List<int> enemyIndex = new List<int>();

        public int minHeight = 1;
        public int maxHeight = 3;
        public int minAmount = 2;
        public int maxAmount = 10;
        public int minEnemyChance;
        public int maxEnemyChance;

        public int enemyCounter = 0;
        bool generateEnemy = false;
        public bool canGenerateDuplicateHeight;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(GenerateLevel());
        }
        //Destroys everything in the previous section and builds a new one
        public void NewSection()
        {
            tilemap.ClearAllTiles();
            DestroyEnemies();
            DestroyClocks();
            if (minEnemyChance != maxEnemyChance) maxEnemyChance--;
            if (enemyCounter == enemyIndex.Count) enemyCounter--;
            if (score.score == enemyIndex[enemyCounter]) enemyCounter++; 
            player.transform.position = new Vector2(0, 3.5f);
            StartCoroutine(GenerateLevel());
        }
        //Destroys all enemies that were present in the previous section when
        //the player progresses to the next one
        private void DestroyEnemies()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject target in enemies)
            {
                if(target.name.Contains("Clone"))
                {
                    Destroy(target);
                }
            }
        }
        //Destroys all clock remaining in the previous section when the player
        //progresses to the next one
        private void DestroyClocks()
        {
            GameObject[] clocks = GameObject.FindGameObjectsWithTag("Clock");
            foreach (GameObject target in clocks)
            {
                if (target.name.Contains("Clock"))
                {
                    Destroy(target);
                }
            }
        }
        //This code generates a new section
        IEnumerator GenerateLevel()
        {
            int columnHeight = 3;
            int previousColumnHeight;
            int columnAmount = 0;
            int maxColumnAmount = Random.Range(minAmount, maxAmount + 1);
            int xposition = -1;
            int yposition = -1;

            int itemGenerator = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int x = 0; x < 2; x++)
                {
                    yposition += 1;
                    Vector3Int position = new Vector3Int(xposition, yposition, 0);
                    tilemap.SetTile(position, tileGround);
                }
                Vector3Int newPosition = new Vector3Int(xposition, yposition, 0);
                tilemap.SetTile(newPosition, tileSurface);

                yposition = -1;
                xposition += 1;
                yield return new WaitForSeconds(0.001f);
            }
            for (int x = 0; x < 186; x++)
            {
                previousColumnHeight = columnHeight;
                if (186 - x <= maxColumnAmount && columnAmount == maxColumnAmount)
                {
                    columnHeight = 3;
                    columnAmount = 0;
                    maxColumnAmount = 186 - x;
                }
                else if (columnAmount == maxColumnAmount)
                {
                    if(canGenerateDuplicateHeight == false)
                    {
                        while (previousColumnHeight == columnHeight)
                        {
                            columnHeight = Random.Range(minHeight, maxHeight + 1);
                            columnAmount = 0;
                            maxColumnAmount = Random.Range(minAmount, maxAmount + 1);
                        }
                    }
                    else
                    {
                        columnHeight = Random.Range(minHeight, maxHeight + 1);
                        columnAmount = 0;
                        maxColumnAmount = Random.Range(minAmount, maxAmount + 1);
                    }
                    if (columnHeight > previousColumnHeight + 2) columnHeight = previousColumnHeight + 2;
                    print("previous" + previousColumnHeight);
                    print("current" + columnHeight);
                }
                else
                {
                    columnAmount += 1;
                }
                if(columnHeight != 0)
                {
                    for (int i = 0; i < columnHeight; i++)
                    {
                        yposition += 1;
                        Vector3Int position = new Vector3Int(xposition, yposition, 0);
                        tilemap.SetTile(position, tileGround);
                    }
                    Vector3Int newPosition = new Vector3Int(xposition, yposition, 0);
                    tilemap.SetTile(newPosition, tileSurface);

                    //This code is used to generate enemies, static hazards, and clocks
                    if (generator.maxEnemyIndex == enemyCounter) generator.maxEnemyIndex++;
                    if (generator.spikeAmount == 1) generator.targetEnemyIndex = Random.Range(generator.minEnemyIndex, generator.maxEnemyIndex);
                    if (generator.generateSpike == generator.spikeAmount || columnHeight != previousColumnHeight)
                    {
                        generator.spikeCooldown = 1;
                        generator.generateSpike = 0;
                        generator.spikeAmount = 1;
                    }
                    if (generator.spikeAmount == 1) itemGenerator = Random.Range(1, maxEnemyChance + 1);
                    if (itemGenerator == 1 && columnHeight == previousColumnHeight && x > 10 && generator.targetEnemyIndex != generator.spikeIndex)
                    {
                        generator.GenerateEnemy(xposition, yposition);
                        generateEnemy = true;
                    }
                    if ((itemGenerator == 1 && generator.spikeAmount == 1 || generator.spikeAmount != 1) && generator.spikeCooldown == 0)
                    {
                        if (generator.targetEnemyIndex == generator.spikeIndex && columnHeight == previousColumnHeight)
                        {
                            generator.GenerateSpike(xposition, yposition);
                            generateEnemy = true;
                        }
                    }
                    itemGenerator = Random.Range(1, 101);
                    if (itemGenerator == 1 && generateEnemy == false) generator.GenerateClock(xposition, yposition);
                }
                generateEnemy = false;
                yposition = -1;
                xposition += 1;
                if (generator.spikeCooldown == 10) generator.spikeCooldown = 0;
                else if (generator.spikeCooldown != 0) generator.spikeCooldown++;
                yield return new WaitForSeconds(0.001f);
            }
            for (int i = 0; i < 8; i++)
            {
                for (int x = 0; x < 3; x++)
                {
                    yposition += 1;
                    Vector3Int position = new Vector3Int(xposition, yposition, 0);
                    tilemap.SetTile(position, tileGround);
                }
                Vector3Int newPosition = new Vector3Int(xposition, yposition, 0);
                tilemap.SetTile(newPosition, tileSurface);

                yposition = -1;
                xposition += 1;
                yield return new WaitForSeconds(0.001f);
            }
        }
    }
}