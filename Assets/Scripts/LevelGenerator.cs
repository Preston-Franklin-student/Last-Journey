using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

namespace LastJourney
{
    public class LevelGenerator : MonoBehaviour
    {
        public Player player;
        public Tilemap tilemap;
        public TileBase tile;
        public ItemGenerator generator;

        public int minHeight = 1;
        public int maxHeight = 3;
        public int minAmount = 2;
        public int maxAmount = 10;
        public int minEnemyChance;
        public int maxEnemyChance;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(GenerateLevel());
        }

        public void NewSection()
        {
            tilemap.ClearAllTiles();
            StartCoroutine(GenerateLevel());
            player.transform.position = new Vector2(0, 3.5f);
            if (minEnemyChance == maxEnemyChance) maxEnemyChance--;
        }

        IEnumerator GenerateLevel()
        {
            int columnHeight = Random.Range(minHeight, maxHeight + 1);
            int columnAmount = 0;
            int maxColumnAmount = Random.Range(minAmount, maxAmount + 1);
            int xposition = 7;
            int yposition = -1;

            int itemGenerator;

            for(int x = 0; x < 186; x++)
            {
                if(186 - x <= maxColumnAmount && columnAmount == maxColumnAmount)
                {
                    columnHeight = 3;
                    columnAmount = 0;
                    maxColumnAmount = 186 - x;
                }
                else if (columnAmount == maxColumnAmount)
                {
                    columnHeight = Random.Range(minHeight, maxHeight + 1);
                    columnAmount = 0;
                    maxColumnAmount = Random.Range(minAmount, maxAmount + 1);
                }
                else
                {
                    columnAmount += 1;
                }
                for (int i = 0; i < columnHeight; i++)
                {
                    yposition += 1;
                    Vector3Int position = new Vector3Int(xposition, yposition, 0);
                    tilemap.SetTile(position, tile);
                }

                itemGenerator = Random.Range(1, 101);
                if (itemGenerator == 1) generator.GenerateClock(xposition, yposition);

                itemGenerator = Random.Range(1, maxEnemyChance + 1);
                if (itemGenerator == 0) generator.GenerateEnemy(xposition, yposition);

                yposition = -1;
                xposition += 1;
                yield return new WaitForSeconds(0.001f);
            }
        }
    }
}
