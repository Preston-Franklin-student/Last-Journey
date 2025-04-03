using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastJourney
{
    public class LevelGenerator : MonoBehaviour
    {
        public GameObject generator;
        public GameObject ground;
        public GameObject clock;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(GenerateLevel());
        }

        IEnumerator GenerateLevel()
        {
            int columnHeight = Random.Range(1, 4);
            int columnAmount = 0;
            int maxColumnAmount = Random.Range(2, 7); ;
            int xposition = 0;
            int yposition = -1;

            int itemGenerator;

            for(int x = 0; x < 100; x++)
            {
                if (columnAmount == maxColumnAmount)
                {
                    columnHeight = Random.Range(1, 4);
                    columnAmount = 0;
                    maxColumnAmount = Random.Range(2, 7);
                }
                else
                {
                    columnAmount += 1;
                }

                for (int i = 0; i < columnHeight; i++)
                {
                    yposition += 1;
                    generator.transform.position = new Vector2(xposition, yposition);
                    Instantiate(ground, transform.position, transform.rotation);
                }
                itemGenerator = Random.Range(1, 21);
                if (itemGenerator == 1)
                {
                    yposition += 1;
                    generator.transform.position = new Vector2(xposition, yposition);
                    Instantiate(clock, transform.position, transform.rotation);
                }

                yposition = -1;
                xposition += 1;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
