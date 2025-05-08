using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
        public BackgroundGenerator generator2;

        public List<int> enemyIndex = new List<int>();

        int generateSurfaceEnemy;
        int generateSurfaceHazard;
        public int minHeight = 1;
        public int maxHeight = 3;
        public int minAmount = 2;
        public int maxAmount = 10;
        public int minEnemyChance;
        public int maxEnemyChance;
        public int minPitSpawnChance;
        public int maxPitSpawnChance;
        public int maxClockChance;
        public int enemyCounter = 0;

        bool generatedSurfaceEnemy = false;
        bool generateEnemy = false;
        public bool canGenerateDuplicateHeight;
        public bool canGeneratePitFalls;
        public bool canGenerateSurfaceHazard;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(GenerateLevel());
            generator2.GenerateBackground();
        }
        //Destroys everything in the previous section and builds a new one
        public void NewSection()
        {
            tilemap.ClearAllTiles();
            DestroyLevelAssets();
            if (minEnemyChance != maxEnemyChance) maxEnemyChance--;
            if (enemyCounter == enemyIndex.Count) enemyCounter--;
            if (score.score == enemyIndex[enemyCounter]) enemyCounter++;
            generator.maxClockCounter++;
            player.transform.position = new Vector2(0, 3.5f);
            StartCoroutine(GenerateLevel());
            generator2.GenerateBackground();
        }
        //Destroys all assets in the current section
        private void DestroyLevelAssets()
        {
            GameObject[] levelAssets = GameObject.FindGameObjectsWithTag("LevelAssets");
            foreach(GameObject target in levelAssets)
            {
                if(target.name.Contains("Clone"))
                {
                    Destroy(target);
                }
            }
        }

        //This code generates a new section
        IEnumerator GenerateLevel()
        {
            int columnHeight = 2;
            int previousColumnHeight;
            int columnAmount = 0;
            int maxColumnAmount = Random.Range(minAmount, maxAmount + 1);
            int previousMaxColumnAmount;
            int spawnPitFall;
            int columnHeightBeforePitFall = 0;
            int xposition = -1;
            int yposition = -1;
            bool generatedSurfaceHazard = false;
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
                previousMaxColumnAmount = maxColumnAmount;
                spawnPitFall = Random.Range(minPitSpawnChance, maxPitSpawnChance + 1);
                if (186 - x <= maxColumnAmount && columnAmount == maxColumnAmount)
                {
                    columnHeight = 3;
                    columnAmount = 0;
                    maxColumnAmount = 186 - x;
                }
                else if (canGeneratePitFalls == true && columnAmount == maxColumnAmount && spawnPitFall == minPitSpawnChance && previousColumnHeight != 0 && 186 - x > maxColumnAmount * 2)
                {
                    columnHeightBeforePitFall = previousColumnHeight;
                    columnHeight = 0;
                    columnAmount = 0;
                    maxColumnAmount = Random.Range(minAmount, maxAmount + 1);
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
                    if(generator.surfaceHazardAmount != 1 && previousColumnHeight != columnHeight && generator.surfaceHazardAmount != 0)
                    {
                        columnHeight = previousColumnHeight;
                    }
                    else
                    {
                    if (previousColumnHeight == 0 && previousMaxColumnAmount >= 4) columnHeight = columnHeightBeforePitFall;
                    else if (previousColumnHeight == 0 && columnHeight > columnHeightBeforePitFall + 2) columnHeight = columnHeightBeforePitFall + 2;
                    else if (columnHeight > previousColumnHeight + 2 && previousColumnHeight != 0) columnHeight = previousColumnHeight + 2;
                        if(generator.justGeneratedSurfaceHazard == true)
                        {
                            columnHeight = previousColumnHeight;
                        }
                    }
                }
                else
                {
                    columnAmount += 1;
                }
                if(columnHeight != 0)
                {
                    for (int i = 0; i < columnHeight - 1; i++)
                    {
                        yposition += 1;
                        Vector3Int position = new Vector3Int(xposition, yposition, 0);
                        tilemap.SetTile(position, tileGround);
                    }
                    yposition += 1;
                    generateSurfaceEnemy = Random.Range(1, maxEnemyChance);
                    generateSurfaceHazard = Random.Range(1, generator.maxSurfceHazardChance);
                    if ((generateSurfaceHazard == 1 && generator.surfaceHazardAmount == 1 || generator.surfaceHazardAmount != 1) && canGenerateSurfaceHazard == true)
                    {
                        if (columnHeight == previousColumnHeight && 186 - x > generator.maxSurfaceHazardAmount * 2 && generator.surfaceHazardCooldown == 0)
                        {
                            generator.GenerateSurfaceHazard(xposition, yposition);
                            generatedSurfaceHazard = true;
                        }
                        else
                        {
                            Vector3Int newPosition = new Vector3Int(xposition, yposition, 0);
                            tilemap.SetTile(newPosition, tileSurface);
                        }
                    }
                    else if (generateSurfaceEnemy == 1 && generator.targetEnemyIndex == generator.surfaceEnemyIndex && x > 10)
                    {
                        generator.GenerateSurfaceEnemy(xposition, yposition);
                        generatedSurfaceEnemy = true;
                    }
                    else
                    {
                        Vector3Int newPosition = new Vector3Int(xposition, yposition, 0);
                        tilemap.SetTile(newPosition, tileSurface);
                    }

                    //This code is used to generate enemies, static hazards, and clocks
                    if (generator.maxEnemyIndex == enemyCounter) generator.maxEnemyIndex++;
                    if (generator.spikeAmount == 1) generator.targetEnemyIndex = Random.Range(generator.minEnemyIndex, generator.maxEnemyIndex);
                    if (generator.generateSpike == generator.spikeAmount || columnHeight != previousColumnHeight || generatedSurfaceHazard == true)
                    {
                        generator.spikeCooldown = 1;
                        generator.generateSpike = 0;
                        generator.spikeAmount = 1;
                    }
                    if (generator.spikeAmount == 1) itemGenerator = Random.Range(1, maxEnemyChance + 1);
                    if (itemGenerator == 1 && columnHeight == previousColumnHeight && x > 10 && generatedSurfaceEnemy == false && generatedSurfaceHazard == false)
                    {
                        if (generator.targetEnemyIndex != generator.surfaceEnemyIndex && generator.targetEnemyIndex != generator.spikeIndex)
                        {
                            generator.GenerateEnemy(xposition, yposition);
                            generateEnemy = true;
                        }
                    }
                    if ((itemGenerator == 1 && generator.spikeAmount == 1 || generator.spikeAmount != 1) && generator.spikeCooldown == 0 && generatedSurfaceEnemy == false && generatedSurfaceHazard == false)
                    {
                        if (generator.targetEnemyIndex == generator.spikeIndex && columnHeight == previousColumnHeight && x > 10)
                        {
                            generator.GenerateSpike(xposition, yposition);
                            generateEnemy = true;
                        }
                    }
                    itemGenerator = Random.Range(1, maxClockChance);
                    if (itemGenerator == 1 && generateEnemy == false && generatedSurfaceEnemy == false) generator.GenerateClock(xposition, yposition);
                }
                generateEnemy = false;
                generatedSurfaceEnemy = false;
                yposition = -1;
                xposition += 1;
                if (generator.spikeCooldown == 5) generator.spikeCooldown = 0;
                else if (generator.spikeCooldown != 0) generator.spikeCooldown++;
                if (generator.surfaceHazardCooldown == 5) generator.surfaceHazardCooldown = 0;
                else if (generator.surfaceHazardCooldown != 0) generator.surfaceHazardCooldown++;
                if (generator.justGeneratedSurfaceHazard == false && generatedSurfaceHazard == true) generatedSurfaceHazard = false;
                if(generator.surfaceHazardCooldown == 3) generator.justGeneratedSurfaceHazard = false;
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